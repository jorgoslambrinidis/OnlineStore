using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineStore.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineStore.API.Helpers
{
    public class IdentityHelper
    {
        internal static void SeedIdentities(DbContext context)
        {
            // user manager init
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            // role manager init
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // check if exists, if not create new roles
            if (!roleManager.RoleExists(RoleNames.ROLE_BASIC))
            {
                var roleResult = roleManager.Create(new IdentityRole(RoleNames.ROLE_BASIC));
            }
            if (!roleManager.RoleExists(RoleNames.ROLE_ADMIN))
            {
                var roleResult = roleManager.Create(new IdentityRole(RoleNames.ROLE_ADMIN));
            }
            if (!roleManager.RoleExists(RoleNames.ROLE_SELLER))
            {
                var roleResult = roleManager.Create(new IdentityRole(RoleNames.ROLE_SELLER));
            }

            // ---> creating users <---
            // get stored username and password for admin
            string username = System.Web.Configuration.WebConfigurationManager.AppSettings["AdminUsername"];
            string password = System.Web.Configuration.WebConfigurationManager.AppSettings["AdminPassword"];
            // get stored username and password for user
            string username2 = System.Web.Configuration.WebConfigurationManager.AppSettings["UserUsername"];
            string password2 = System.Web.Configuration.WebConfigurationManager.AppSettings["UserPassword"];
            // get stored username and password for seller
            string username3 = System.Web.Configuration.WebConfigurationManager.AppSettings["SellerUsername"];
            string password3 = System.Web.Configuration.WebConfigurationManager.AppSettings["SellerPassword"];

            ApplicationUser userAdmin = userManager.FindByName(username);
            ApplicationUser userUser = userManager.FindByName(username2);
            ApplicationUser userSeller = userManager.FindByName(username3);

            if(userAdmin == null || userUser == null || userSeller == null)
            {
                userAdmin = new ApplicationUser()
                {
                    UserName = username,
                    Email = username,
                    EmailConfirmed = true
                };

                userUser = new ApplicationUser()
                {
                    UserName = username2,
                    Email = username2,
                    EmailConfirmed = true
                };

                userSeller = new ApplicationUser()
                {
                    UserName = username3,
                    Email = username3,
                    EmailConfirmed = true
                };

                // create admin user role
                IdentityResult userResult = userManager.Create(userAdmin, password);
                // create user user role
                IdentityResult userResult2 = userManager.Create(userUser, password2);
                // create seller user role
                IdentityResult userResult3 = userManager.Create(userSeller, password3);

                // create roles for the created users
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(userAdmin.Id, RoleNames.ROLE_ADMIN);
                }
                if(userResult2.Succeeded)
                {
                    var result2 = userManager.AddToRole(userUser.Id, RoleNames.ROLE_BASIC);
                }
                if (userResult3.Succeeded)
                {
                    var result3 = userManager.AddToRole(userSeller.Id, RoleNames.ROLE_SELLER);
                }
            }
        }
    }
}