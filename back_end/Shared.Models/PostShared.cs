using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class PostShared
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AmountDrank { get; set; }
        public DrinkType DrinkType { get; set; }
    }
}
