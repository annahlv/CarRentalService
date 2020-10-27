using System.Collections.Generic;
using System.Linq;

namespace DiplomProject.Models
{

    public class EFUserRepository : IUserRepository
    {
        private ApplicationDbContext context;

        public EFUserRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<ApplicationUser> Users => context.AppUsers;
        public void SaveUser(ApplicationUser user)
        {
            if (user.Id == null)
            {
                context.Users.Add(user);
            }
            else
            {
                ApplicationUser dbEntry = context.AppUsers
                    .FirstOrDefault(p => p.Id == user.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = user.Name;
                    dbEntry.Surname = user.Surname;
                    dbEntry.Phone = user.Phone;
                    dbEntry.Address = user.Address;
                    dbEntry.City = user.City;
                    dbEntry.Photo = user.Photo;

                }

            }
            context.SaveChanges();
        }
    }
}
