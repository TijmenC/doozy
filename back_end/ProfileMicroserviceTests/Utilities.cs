using ProfileMicroservice;
using ProfileMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileMicroserviceTests
{
    class Utilities
    {
        public static void InitializeDbForTests(DBContext db)
        {
            db.Users.AddRange(GetSeedingUsers());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(DBContext db)
        {
            db.Users.RemoveRange(db.Users);
            InitializeDbForTests(db);
        }

        public static List<User> GetSeedingUsers()
        {
            return new List<User>()
    {
        new User(){Id = 1, UserName = "Eric", Email = "Eric@gmail.com", DisplayName = "Erica4Cool", DateOfBirth = new DateTime(2000, 3, 29)},
        new User(){Id = 2, UserName = "Erica", Email = "Erica@gmail.com", DisplayName = "Erica4Cool", DateOfBirth = new DateTime(1999, 3, 29)},
        new User(){Id = 3, UserName = "Peter", Email = "Peter@gmail.com", DisplayName = "Peter4Cool", DateOfBirth = new DateTime(1998, 3, 29)},
         new User(){Id = 4, UserName = "Nol", Email = "Nol@gmail.com", DisplayName = "Nol4Cool", DateOfBirth = new DateTime(1998, 3, 29)},
    };
        }
    }
}
