using LobbyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyMicroservice
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
                    DateOfBirth =  new DateTime(2000, 2, 29),
                    DisplayName = "Eric",
                    UserName = "CoolEric",
                    Email = "EricIsCool@gmail.com"

                },
                 new User
                {
                    DateOfBirth =  new DateTime(2000, 2, 29),
                    DisplayName = "Patrick",
                    UserName = "CoolPatrick",
                    Email = "PatrickIsCool@gmail.com"

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
