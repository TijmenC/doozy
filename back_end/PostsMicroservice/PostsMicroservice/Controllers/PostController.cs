using MassTransit;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _DBContext.Post.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
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
        public async Task<HttpStatusCode> InsertPost(Post Post)
        {
            var entity = new Post()
            {
                Id = Post.Id,
                UserId = Post.Id,
                Title = Post.Title,
                Description = Post.Description,
                AmountDrank = Post.AmountDrank,
                DrinkType = Post.DrinkType
            };

            _DBContext.Post.Add(entity);
            await _DBContext.SaveChangesAsync();

            return HttpStatusCode.Created;
        }
    }
  }
