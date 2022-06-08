using MassTransit;
using Microsoft.Extensions.Logging;
using ProfileMicroservice.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMicroservice.Consumers
{
    public class Consumer : IConsumer<PostShared>
    {
        private readonly ILogger<Consumer> logger;

        private readonly DBContext _DBContext;
        public Consumer(ILogger<Consumer> logger, DBContext DBContext)
        {
            this.logger = logger;
            _DBContext = DBContext;
        }
        public Task Consume(ConsumeContext<PostShared> context)
        {
            /*
            PostShared post = new PostShared()
            {
                Id = context.Message.Id,
                UserId = context.Message.Id,
                Title = context.Message.Title,
                Description = context.Message.Description,
                AmountDrank = context.Message.AmountDrank,
                DrinkType = context.Message.DrinkType
            };

            _DBContext.Posts.Add(post);
            _DBContext.SaveChanges();
            */
            return Task.CompletedTask;
        }
    }
}
