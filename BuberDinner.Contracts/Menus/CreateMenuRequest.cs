using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BuberDinner.Contracts.Menus
{
    public record CreateMenuRequest
    (
        string Name, 
        string Description,
        List<MenuSection> Sections         
    );

    public record MenuSection(
        string Name, 
        string Descriptions,
        List<MenuItem> Items
    );

    public record MenuItem(
        string Name,
        string Description
    );
    
}