using DC_Comic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Http;

namespace DC_Comic.Controllers.Api
{
    public class CharactersController : ApiController
    {
        private ApplicationDbContext _context;

        public CharactersController()
        {
            _context = new ApplicationDbContext();

        }

        //Get/APi/Character
        [System.Web.Mvc.Authorize]
        public IEnumerable<Character> GetCharacter()
        {
            return _context.Characters.ToList();
        }

        //Api/Character/2
        [System.Web.Mvc.Authorize]

        public Character GetCharacter(int id)
        {
            var Character = _context.Characters.SingleOrDefault(a => a.Id == id);
            Character.Alignment = _context.Alignments.FirstOrDefault(g => g.Id == Character.Id);

            if (Character == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            return Character;
        }
        [System.Web.Http.HttpPost]
        public Character CreateCharacter(Character character)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Characters.Add(character);
            _context.SaveChanges();

            return character;
        }
        // Put /Api/Character/5
        [System.Web.Http.HttpPut]
        public void UpdateCharacter(int id, Character character)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var characterInDb = _context.Characters.SingleOrDefault(m => m.Id == id);

            if (characterInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            characterInDb.Name = character.Name;
            characterInDb.Powers = character.Powers;
            characterInDb.Occupation = character.Occupation;
            characterInDb.Id = character.Id;
            characterInDb.Location = character.Location;
            characterInDb.picString = character.picString;
            characterInDb.profilePic = character.profilePic;
            characterInDb.Alignment = character.Alignment;
            characterInDb.AlignmentId = character.AlignmentId;


            _context.SaveChanges();
        }

        // Delete /Api/Character/5
        [System.Web.Http.HttpDelete]
        public void DeleteCharacter(int id)
        {
            var characterInDb = _context.Characters.SingleOrDefault(m => m.Id == id);

            if (characterInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Characters.Remove(characterInDb);
            _context.SaveChanges();
        }

    }
}
