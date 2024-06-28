using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employeemanagement.Model;
using Employeemanagement.Context;
using System.Xml.XPath;

namespace Employeemanagement.Service
{
    public class UserService : IUserService
    {

        private readonly ApplicationDataContext appDataContext;
        public UserService(ApplicationDataContext applicationDataContext)
        {
            this.appDataContext = applicationDataContext;
        }
        public List<User> GetAllUsers()
        {
            return this.appDataContext.Users.ToList();
        }
        public User GetUserById(int userId)
        {
            return this.appDataContext.Users.SingleOrDefault(x => x.Id == userId);
        }
        public User GetUserByName(string userName)
        {
            return this.appDataContext.Users.SingleOrDefault(x => x.Name == userName);
        }
        public User VerifyCredential(string emailId, string password)
        {
            return this.appDataContext.Users.SingleOrDefault(x => x.EmailId == emailId && x.Password == password);
        }

        public bool CheckUserExists(User user)
        {
            var data = this.appDataContext.Users.SingleOrDefault(x => x.EmailId == user.Name);
            return (data is not null);
        }
        public User AddUser(User user)
        {
            this.appDataContext.Users.Add(user);
             this.appDataContext.SaveChanges();
            return user;
        }

    }
}