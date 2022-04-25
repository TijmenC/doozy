using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PostsMicroservice.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set;  }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AmountDrank { get; set; }
        public DrinkType DrinkType { get; set; }
    }
}
