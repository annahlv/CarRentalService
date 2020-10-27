using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomProject.Models
{
    public interface IOrderStateRepository
    {
        IQueryable<OrderState> States { get; }
    }
}
