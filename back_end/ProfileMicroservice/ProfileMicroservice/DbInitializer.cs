using ProfileMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMicroservice
{
    public static class DbInitializer
    {
        public static void Initialize(DBContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }
            
            var subjects = new User[]
            {
                new User
                {
                    DateOfBirth =  new DateTime(2000, 1, 29),
                    DisplayName = "Eric",
                    UserName = "CoolEric",
                    Email = "EricIsCool@gmail.com",
                    DeletionTime = new DateTime(2024, 5, 29)

                },
                new User
                {
                    DateOfBirth =  new DateTime(2000, 4, 29),
                    DisplayName = "Patrick",
                    UserName = "CoolPatrick",
                    Email = "PatrickIsCool@gmail.com",
                    DeletionTime = new DateTime(2024, 8, 25)

                },
                new User
                {
                    DateOfBirth =  new DateTime(2000, 6, 29),
                    DisplayName = "Evelyn",
                    UserName = "CoolEvelyn",
                    Email = "EvelynIsCool@gmail.com",
                    DeletionTime = new DateTime(2022, 4, 25)

                },
            };

            foreach (User subject in subjects)
            {
                context.Users.Add(subject);
            }
            context.SaveChanges();
        }
    }
}
