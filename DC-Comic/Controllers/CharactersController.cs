using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DC_Comic.Models;
using DC_Comic.ViewModels;
using System.Data.Entity;
using System.Net;
using System.IO;

namespace DC_Comic.Controllers
{
    public class CharactersController : Controller
    {
        private ApplicationDbContext _context;
        // constructor
        public CharactersController()
        {
            _context = new ApplicationDbContext();
        }
        // disposable object
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {

            
            var character = _context.Characters.Include(b => b.Alignment).ToList(); // immediate execution

            return View(character);
        }

        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            var characters = _context.Characters.SingleOrDefault(a => a.Id == id);
            // immediate execution because of above extension method 
            if (characters == null)
            {
                return HttpNotFound();
            }

            return View(characters);
        }

        [Authorize(Roles = "CanManageCharacters")]
         public ActionResult New()
        {
            var AlignmentTypes = _context.Alignments.ToList();
            var character = new Character();
            var ViewModel = new CharacterFormViewModel
            {
                Character = character,
                Alignment = AlignmentTypes
            };

            // will need a form that contains Book details as well as the genre info so need a new viewmodel

            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult Create(CharacterFormViewModel ViewModel)
        {
            _context.Characters.Add(ViewModel.Character);
            _context.SaveChanges();
            return RedirectToAction("Index", "Characters");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CharacterFormViewModel viewModel, string fileName, string extension)
        {

            viewModel.Character.Alignment = _context.Alignments.First(g => g.Id == viewModel.Character.AlignmentId);
            if (!ModelState.IsValid)
            {

                viewModel = new CharacterFormViewModel
                {
                    Character = viewModel.Character,

                    Alignment = _context.Alignments.ToList() // taken from db
                };

                return View("New", viewModel);
            }

            if (viewModel.Character.Id == 0) { 
                fileName = Path.GetFileName(viewModel.ImageFile.FileName);
            viewModel.Character.profilePic =  fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/Profile/"), fileName);
            viewModel.ImageFile.SaveAs(fileName);

            _context.Characters.Add(viewModel.Character); }
            else
            {
                var CharacterInDb = _context.Characters.Single(c => c.Id == viewModel.Character.Id);
                CharacterInDb.Name = viewModel.Character.Name;
                CharacterInDb.Powers = viewModel.Character.Powers;
                CharacterInDb.Occupation = viewModel.Character.Occupation;
                CharacterInDb.Location = viewModel.Character.Location;
                CharacterInDb.AlignmentId = viewModel.Character.AlignmentId;
               // CharacterInDb.picString = viewModel.Character.picString;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Characters");
        }

        [Authorize(Roles = "CanManageCharacters")]
        public ActionResult Edit(int id)
        {

            var character = _context.Characters.SingleOrDefault(b => b.Id == id);

            if (character == null)
                return HttpNotFound();

            var viewModel = new CharacterFormViewModel
            {
                Character = character,
                Alignment = _context.Alignments.ToList()
            };

            return View("New", viewModel);
        }

        [Authorize(Roles = "CanManageCharacters")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = _context.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CharacterFormViewModel
            {
                Character = character,
                Alignment = _context.Alignments.ToList()
            };
            return View("Delete", viewModel);
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            Character character = _context.Characters.Find(id);
            _context.Characters.Remove(character);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}