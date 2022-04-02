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
    public class QuestionController : ControllerBase
    {
        private readonly PostContext _context;

        public QuestionController(PostContext context)
        {
            _context = context;
        }

        // GET: api/Question/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> GetQuestion(int id)
        {
            var question = await _context.Posts.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return QuestionToDTO(question);
        }

        private static PostDTO QuestionToDTO(Post todoItem) =>
      new PostDTO
      {
          Id = todoItem.Id,
          Title = todoItem.Title,
          Description = todoItem.Description
      };
    }
  }
