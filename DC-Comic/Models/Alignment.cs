using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DC_Comic.Models
{
    public class Alignment
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string alignmentType { get; set; }
    }
}
