using PostsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsMicroservice
{
    public static class DbInitializer
    {
        public static void Initialize(DBContext context)
        {
            context.Database.EnsureCreated();

            if (context.Post.Any())
            {
                return;
            }
            
            var subjects = new Post[]
            {
                new Post
                {
                    UserId = 0,
                    Title = "Drank so much!",
                    Description = "Doozy",
                    AmountDrank = 8,
                    DrinkType = DrinkType.Beer

                },
                 new Post
                {
                    UserId = 0,
                    Title = "Drank so much again!",
                    Description = "Doozy",
                    AmountDrank = 11,
                    DrinkType = DrinkType.Beer
                },
            };

            foreach (Post subject in subjects)
            {
                context.Post.Add(subject);
            }
            context.SaveChanges();
        }
    }
}
