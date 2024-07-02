using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employeemanagement.Model;

namespace Employeemanagement.Service
{
    public interface IUserService
    {
        User AddUser(User user);
        bool CheckUserExists(User user);
        List<User> GetAllUsers();
        User GetUserById(int userId);
        User GetUserByName(string userName);
        User VerifyCredential(string emailId, string password);
        User UpdateUser(User user);
        User DeleteUser(User user);
    }
}