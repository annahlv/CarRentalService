using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DiplomProject.Models
{

    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;

        public EFOrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Order> Orders => context.Orders;

        public void SaveOrder(Order order)
        {
            context.Attach(order.Car);
            if (order.Id == 0)
            {
                context.Orders.Add(order);
            }
            else
            {
                Order dbEntry = context.Orders
                    .FirstOrDefault(p => p.Car.Id == order.Car.Id);
                if (dbEntry != null)
                {
                    dbEntry.CarId = order.CarId;
                    dbEntry.UserId = order.UserId;
                    dbEntry.StateId = order.StateId;
                    dbEntry.Car = order.Car;
                    dbEntry.User = order.User;
                    dbEntry.OrderPlaced = order.OrderPlaced;
                    dbEntry.OrderApproved = order.OrderApproved;
                    dbEntry.State = order.State;
                    dbEntry.StartRent = order.StartRent;
                    dbEntry.EndRent = order.EndRent;
                }

            }

            context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            Order dbEntry = context.Orders
                    .FirstOrDefault(p => p.Id == order.Id);
            if (dbEntry != null)
            {
                dbEntry.CarId = order.CarId;
                dbEntry.UserId = order.UserId;
                dbEntry.State = order.State;
                dbEntry.StateId = order.StateId;
                dbEntry.Car = order.Car;
                dbEntry.User = order.User;
                dbEntry.OrderPlaced = order.OrderPlaced;
                dbEntry.OrderApproved = order.OrderApproved;
                dbEntry.StartRent = order.StartRent;
                dbEntry.EndRent = order.EndRent;
            }
            context.SaveChanges();
        }
    }

}
