using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        void EditUser(User user);
        void DeleteUser(int userId);

        User GetUserById(int userId);
        IEnumerable<User> GetUsers();
        IQueryable<User> GetUsersQueryable();
    }
}
