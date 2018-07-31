using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DC_Comic.ViewModels
{
    public class mainModel

    {
        public CharacterFormViewModel CharacterFormView { get; set; }
        public IEnumerable<DC_Comic.Models.Character> Character { get; set; }

    }
}