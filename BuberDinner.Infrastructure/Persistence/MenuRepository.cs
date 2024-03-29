using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Menu;
using BuberDinner.Domain.Menu;

namespace BuberDinner.Infrastructure.Persistence
{
    public class MenuRepository : IMenuRepository

    {
        private static readonly List<Menu> _menus = new();

        public void Add(Menu menu)
        {
            _menus.Add(menu);
        }
    }
}