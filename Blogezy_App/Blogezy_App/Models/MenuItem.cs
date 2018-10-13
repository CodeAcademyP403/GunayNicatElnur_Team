using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogezy_App.Models
{
    public class MenuItem
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        [Required]
        public bool Visibility { get; set; }
    }
}
