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
                    Title = "Title",
                    Description = "Description"
                },
                 new Post
                {
                    Title = "Title2",
                    Description = "Description2"
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
