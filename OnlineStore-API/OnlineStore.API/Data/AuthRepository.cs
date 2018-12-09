using Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineStore.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnlineStore.API.Data
{
    //public class AuthRepository : IDisposable
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if (user == null)
            {
                return null;
            }

            byte[] bytes1 = Encoding.ASCII.GetBytes(user.PasswordHash);

            if (!VerifyPasswordHash(password, bytes1))
            {
                return null;
            }

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordHash))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        //private AuthContext _ctx;

        //private UserManager<IdentityUser> _userManager;

        //public AuthRepository()
        //{
        //    _ctx = new AuthContext();
        //    _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        //}

        //public async Task<IdentityResult> RegisterUser(User userModel)
        //{
        //    IdentityUser user = new IdentityUser
        //    {
        //        UserName = userModel.Name
        //    };

        //    var result = await _userManager.CreateAsync(user, userModel.Password);

        //    return result;
        //}

        //public async Task<IdentityUser> FindUser(string userName, string password)
        //{
        //    IdentityUser user = await _userManager.FindAsync(userName, password);

        //    return user;
        //}

        //public void Dispose()
        //{
        //    _ctx.Dispose();
        //    _userManager.Dispose();
        //}

    }
}