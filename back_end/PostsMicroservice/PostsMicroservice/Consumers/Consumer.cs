using MassTransit;
using Microsoft.Extensions.Logging;
using PostsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace PostsMicroservice.Consumers
{
    public class Consumer : IConsumer<UserShared>
    {
        private readonly ILogger<Consumer> logger;
        public Consumer(ILogger<Consumer> logger)
        {
            this.logger = logger;
        }
        public Task Consume(ConsumeContext<UserShared> context)
        {
            var data = context.Message;
            return null;
        }
    }
}
