using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PostsMicroservice.DTO;
using PostsMicroservice.Models;
using Shared.Models;
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
        private readonly PostContext _context;

        private readonly IBus _bus;

        private readonly DBContext DBContext;
        public PostController(IBus bus, DBContext DBContext)
        {
            _bus = bus;
            this.DBContext = DBContext;
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
        /*
        [HttpPost]
        public async Task<IActionResult> CreateTicket(PostShared ticket)
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
        */
        [HttpPost("InsertUser")]
        public async Task<HttpStatusCode> InsertUser(PostDTO Post)
        {
            var entity = new Post()
            {
                Id = Post.Id,
                Title = Post.Title,
                Description = Post.Description
            };

            DBContext.Post.Add(entity);
            await DBContext.SaveChangesAsync();

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
