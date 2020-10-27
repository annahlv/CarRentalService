using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;


namespace DiplomProject.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";

        //public static async Task EnsurePopulated(UserManager<ApplicationUser> userManager)
        //{

        //    ApplicationUser user = await userManager.FindByIdAsync(adminUser);
        //    if (user == null)
        //    {
        //        user = new ApplicationUser("Admin");
        //        await userManager.CreateAsync(user, adminPassword);
        //    }
        //}

    }
}
