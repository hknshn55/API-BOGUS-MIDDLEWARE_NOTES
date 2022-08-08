
using Bogus;
using Example.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.API.DataAccess
{
     public static class Context
    {
        public static List<User> users = new List<User>();
        public static void UserAdd(List<User> user)
        {
            users.AddRange(user);
        }
        public static List<User> GetUsers()
        {
            return users;
        }
    }
}
