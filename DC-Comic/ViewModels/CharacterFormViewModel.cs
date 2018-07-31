
using DC_Comic.Models;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DC_Comic.ViewModels
{
    public class CharacterFormViewModel
    {
        public IEnumerable<Alignment> Alignment { get; set; }

        public Character Character { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }


    }
}
