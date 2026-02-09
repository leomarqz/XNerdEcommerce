
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using XNerd.Ecommerce.Application.Models.Authorization;
using XNerd.Ecommerce.Domain.Constants;
using XNerd.Ecommerce.Domain.Models;

namespace XNerd.Ecommerce.Infrastructure.Persistence
{
    public static class EcommerceDbContextData
    {
        public static async Task LoadDataAsync(EcommerceDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ILoggerFactory loggerFactory)
        {
            try
            {
                
                if( !roleManager.Roles.Any())
                {
                    await roleManager.CreateAsync( new IdentityRole(Role.ADMIN) );
                    await roleManager.CreateAsync( new IdentityRole(Role.USER) );
                }

                if( !userManager.Users.Any() )
                {
                    var admin = new User
                    {
                        FirstName = "X",
                        LastName = "Nerd",
                        Email = "x.nerd@gmail.com",
                        UserName = "x-nerd",
                        PhoneNumber = "56843948",
                        AvatarUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/avatar-1.webp?alt=media&token=58da3007-ff21-494d-a85c-25ffa758ff6d"
                    };

                    await userManager.CreateAsync(admin, "$ABClmX123&");
                    await userManager.AddToRoleAsync(admin, Role.ADMIN);
                    
                }

            }catch(Exception e)
            {
                var logger = loggerFactory.CreateLogger( typeof(EcommerceDbContextData) );
                logger.LogError(e.Message);
            }
        }
    }
}