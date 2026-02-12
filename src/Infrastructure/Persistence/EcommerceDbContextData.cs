
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
                        Email = "x-nerd@gmail.com",
                        UserName = "x-nerd",
                        PhoneNumber = "56843948",
                        AvatarUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/avatar-1.webp?alt=media&token=58da3007-ff21-494d-a85c-25ffa758ff6d"
                    };

                    await userManager.CreateAsync(admin, "$ABClmX123&");
                    await userManager.AddToRoleAsync(admin, Role.ADMIN);

                    var user = new User
                    {
                        FirstName = "X",
                        LastName = "User",
                        Email = "x-user@gmail.com",
                        UserName = "x-User",
                        PhoneNumber = "56843948",
                        AvatarUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/avatar-1.webp?alt=media&token=58da3007-ff21-494d-a85c-25ffa758ff6d"
                    };

                    await userManager.CreateAsync(user, "$ABCuserX123&");
                    await userManager.AddToRoleAsync(user, Role.USER);
                    
                }

                if( !context.Categories.Any())
                {
                    string categoryData = File.ReadAllText("../Infrastructure/Data/category.json");
                    List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(categoryData)!;
                    await context.Categories.AddRangeAsync(categories);
                    await context.SaveChangesAsync();
                }

                if(!context.Products.Any() )
                {
                    string productData = File.ReadAllText("../Infrastructure/Data/product.json");
                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(productData)!;
                    await context.Products.AddRangeAsync( products );
                    await context.SaveChangesAsync();
                }

                if( !context.Images.Any())
                {
                    string imageData = File.ReadAllText("../Infrastructure/Data/image.json");
                    List<Image> images = JsonConvert.DeserializeObject<List<Image>>(imageData)!;
                    await context.Images.AddRangeAsync( images );
                    await context.SaveChangesAsync();
                }

                if( !context.Reviews.Any())
                {
                    string reviewData = File.ReadAllText("../Infrastructure/Data/review.json");
                    List<Review> reviews = JsonConvert.DeserializeObject<List<Review>>(reviewData)!;
                    await context.Reviews.AddRangeAsync( reviews );
                    await context.SaveChangesAsync();
                }

                if( !context.Countries.Any())
                {
                    string countryData = File.ReadAllText("../Infrastructure/Data/countries.json");
                    List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(countryData)!;
                    await context.Countries.AddRangeAsync( countries );
                    await context.SaveChangesAsync();
                }

            }catch(Exception e)
            {
                var logger = loggerFactory.CreateLogger( typeof(EcommerceDbContextData) );
                logger.LogError(e.Message);
            }
        }
    }
}