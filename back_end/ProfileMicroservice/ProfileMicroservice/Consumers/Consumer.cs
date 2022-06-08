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
        public Consumer(ILogger<Consumer> logger)
        {
            this.logger = logger;
        }
        public Task Consume(ConsumeContext<PostShared> context)
        {
            var data = context.Message;
            return null;
        }
    }
}
