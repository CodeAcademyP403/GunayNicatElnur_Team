using Blogezy_App.Data;
using Blogezy_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogezy_App.Components
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly BlogezyDbContext _blogezyDbContext;

        public MenuViewComponent(BlogezyDbContext blogezyDbContext)
        {
            _blogezyDbContext = blogezyDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Menu> Menus= await _blogezyDbContext.Menus.Include(x => x.SubMenus).ToListAsync();

            return View(Menus);
        }
    }
}
