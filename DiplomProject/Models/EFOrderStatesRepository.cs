using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomProject.Models
{
    public class EFOrderStatesRepository : IOrderStateRepository
    {
        private ApplicationDbContext context;

        public EFOrderStatesRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<OrderState> States => context.States;
    }
}
