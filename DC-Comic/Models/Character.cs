using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DC_Comic.Models
{
    public class Character
    {

        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Powers { get; set; }

        [Required]
        public String Occupation { get; set; }

        [Required]
        public String Location { get; set; }

        [Display(Name = "Alignment")]

        public Alignment Alignment { get; set; }
        public int AlignmentId { get; set; }

        public string picString { get; set; }

        public string profilePic { get; set; }


    }


    
}
