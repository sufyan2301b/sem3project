using Microsoft.AspNetCore.Identity;

namespace TARS_Delivery_System.Models
{
    public class RoleSeeder
    {
        public static  async Task SeedRoles(IServiceProvider serviceProvider)
        {
          var rolemanager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = { "Admin", "User" };
            foreach(var role in roles) {
            if(!await rolemanager.RoleExistsAsync(role))
                {
                    await rolemanager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
