using PostsMicroservice;
using PostsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostsMicroserviceTests
{
    class Utilities
    {
        public static void InitializeDbForTests(DBContext db)
        {
            db.Post.AddRange(GetSeedingPosts());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(DBContext db)
        {
            db.Post.RemoveRange(db.Post);
            InitializeDbForTests(db);
        }

        public static List<Post> GetSeedingPosts()
        {
            return new List<Post>()
    {
        new Post(){Id = 1, UserId = 1, AmountDrank = 1, Description = "Description1", DrinkType = DrinkType.Beer, Title = "Title"},
        new Post(){Id = 2, UserId = 2, AmountDrank = 2, Description = "Description2", DrinkType = DrinkType.Beer, Title = "Title2"},
        new Post(){Id = 3, UserId = 3, AmountDrank = 3, Description = "Description3", DrinkType = DrinkType.Beer, Title = "Title3"},
         new Post(){Id = 4, UserId = 4, AmountDrank = 4, Description = "Description4", DrinkType = DrinkType.Beer, Title = "Title4"},
    };
        }
    }
}
