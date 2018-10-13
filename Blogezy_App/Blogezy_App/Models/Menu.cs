using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogezy_App.Models
{
    public class Menu:MenuItem
    {
        public Menu()
        {
            SubMenus = new HashSet<SubMenu>();
        }

        public virtual ICollection<SubMenu> SubMenus { get; set; }
    }
}
