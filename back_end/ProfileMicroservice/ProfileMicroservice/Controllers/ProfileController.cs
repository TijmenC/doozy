using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ProfileMicroservice.DTO;
using ProfileMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProfileMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        private readonly IBus _bus;

        private readonly DBContext _DBContext;
        public ProfileController(IBus bus, DBContext DBContext)
        {
            _bus = bus;
            _DBContext = DBContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var post = await _DBContext.Users.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }
        [HttpPost("Profile")]
        public async Task<IActionResult> CreateTicket(User user)
        {
            if (user != null)
            {
                Uri uri = new Uri("amqp://guest:guest@rabbitmq:5672/profileQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(user);
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("SaveProfile")]
        public async Task<HttpStatusCode> InsertUser(User Post)
        {
            var entity = new User()
            {
                Id = 0,
                DateOfBirth = new DateTime(2000, 2, 29),
                DisplayName = "Eric",
                UserName = "CoolEric",
                Email = "EricIsCool@gmail.com"
            };

            _DBContext.Users.Add(entity);
            await _DBContext.SaveChangesAsync();

            return HttpStatusCode.Created;
        }
    }
}
