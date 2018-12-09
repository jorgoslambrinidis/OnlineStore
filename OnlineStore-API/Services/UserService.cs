using Data;
using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IDbContext _context;

        public UserService(IDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            User user = _context.Users.Find(userId);
            _context.Users.Remove(user);
        }

        public void EditUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public User GetUserById(int userId)
        {
            var result = _context.Users.FirstOrDefault(x => x.Id == userId);
            return result;
        }

        public IEnumerable<User> GetUsers()
        {
            var result = _context.Users.OrderBy(x => x.Id).ToList();
            return result;
        }

        public IQueryable<User> GetUsersQueryable()
        {
            var result = _context.Users.OrderBy(x => x.Id).ToList().AsQueryable();
            return result;
        }
    }
}