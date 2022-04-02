using Microsoft.AspNetCore.Mvc;
using PostsMicroservice.DTO;
using PostsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostContext _context;

        public PostController(PostContext context)
        {
            _context = context;
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return PostToDTO(post);
        }

        private static PostDTO PostToDTO(Post todoItem) =>
      new PostDTO
      {
          Id = todoItem.Id,
          Title = todoItem.Title,
          Description = todoItem.Description
      };
    }
  }
