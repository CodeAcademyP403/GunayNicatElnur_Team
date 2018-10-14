using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogezy_App.Models
{
    public class SubMenu:MenuItem
    {

        public int MenuId { get; set; }
        public Menu Menu { get; set; }

    }
}
