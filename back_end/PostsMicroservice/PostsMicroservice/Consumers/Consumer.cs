using MassTransit;
using Microsoft.Extensions.Logging;
using PostsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsMicroservice.Consumers
{
    public class Consumer : IConsumer<Post>
    {
        private readonly ILogger<Consumer> logger;
        public Consumer(ILogger<Consumer> logger)
        {
            this.logger = logger;
        }
        public Task Consume(ConsumeContext<Post> context)
        {
            var data = context.Message;
            return null;
        }
    }
}
