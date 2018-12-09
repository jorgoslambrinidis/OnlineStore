using Entities;
using OnlineStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.API.Data
{
    public interface IAuthRepository
    {
        Task<ApplicationUser> Login(string username, string password);
    }
}
