using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DONDE_INVIERTO.Web.DAL
{
    public static class Repository
    {
        static List<User> users = new List<User>() {
            new User() {Email="abc@gmail.com",Roles="Admin,Editor",Password="abcadmin" },
            new User() {Email="xyz@gmail.com",Roles="Editor",Password="xyzeditor" }
        };

        public static User GetUserDetails(User user)
        {
            return users.Where(u => u.Email.ToLower() == user.Email.ToLower() &&
            u.Password == user.Password).FirstOrDefault();
        }
    }
}