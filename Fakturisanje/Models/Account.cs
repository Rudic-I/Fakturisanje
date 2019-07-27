using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fakturisanje.Models
{
    public class Account
    {
        //check user credentials
        public static User CheckUser(LoginViewModel model)
        {
            using (FakturisanjeEntities dbEntity = new FakturisanjeEntities())
            {
                User user = (from u in dbEntity.Users
                             where u.Role == model.Username && u.Password == model.Password
                             select u).SingleOrDefault();

                return user;
            }
        }
    }
}