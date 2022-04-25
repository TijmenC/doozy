using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyMicroservice.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
