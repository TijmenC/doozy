using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PostsMicroservice.DTO;
using PostsMicroservice.Models;
using Shared.Models;
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

        private readonly IBus _bus;
        public PostController(IBus bus, PostContext context)
        {
            _bus = bus;
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

        [HttpPost]
        public async Task<IActionResult> CreateTicket(PostShared ticket)
        {
            if (ticket != null)
            {
                Uri uri = new Uri("rabbitmq://localhost/postsQueue2");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(ticket);
                return Ok();
            }
            return BadRequest();
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
