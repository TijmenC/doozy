using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PostsMicroservice.DTO;
using PostsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PostsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IBus _bus;

        private readonly DBContext _DBContext;
        public PostController(IBus bus, DBContext DBContext)
        {
            _bus = bus;
            _DBContext = DBContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> GetPost(int id)
        {
            var post = await _DBContext.Post.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return PostToDTO(post);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> CreateTicket(Post ticket)
        {
            if (ticket != null)
            {
                Uri uri = new Uri("amqp://guest:guest@rabbitmq:5672/postQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(ticket);
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("SavePost")]
        public async Task<HttpStatusCode> InsertPost(PostDTO Post)
        {
            var entity = new Post()
            {
                Id = Post.Id,
                Title = Post.Title,
                Description = Post.Description
            };

            _DBContext.Post.Add(entity);
            await _DBContext.SaveChangesAsync();

            return HttpStatusCode.Created;
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
