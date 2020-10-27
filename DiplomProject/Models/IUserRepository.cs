using System.Linq;

namespace DiplomProject.Models {

    public interface IUserRepository 
    {

        IQueryable<ApplicationUser> Users { get; }
        void SaveUser(ApplicationUser user);

    }
}
