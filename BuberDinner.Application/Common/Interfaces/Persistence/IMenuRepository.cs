using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Menu;
using BuberDinner.Domain.Menu;

namespace BuberDinner.Application.Common.Interfaces.Persistence
{
    public interface IMenuRepository 
    {


     void Add(Menu menu);   
    }
}