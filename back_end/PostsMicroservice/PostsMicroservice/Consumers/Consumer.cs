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
        private readonly DBContext _DBContext;
        public Consumer(ILogger<Consumer> logger, DBContext DBContext)
        {
            this.logger = logger;
            _DBContext = DBContext;
        }
        public Task Consume(ConsumeContext<UserShared> context)
        {
            /*
             UserShared user = new UserShared()
             {
                 Id = context.Message.Id,
                 DateOfBirth = context.Message.DateOfBirth,
                 DisplayName = context.Message.DisplayName,
                 UserName = context.Message.UserName,
                 Email = context.Message.Email,
                 DeletionTime = context.Message.DeletionTime
             };


             _DBContext.Users.Add(user);
             _DBContext.SaveChanges();
            */

            return Task.CompletedTask;
        }
    }
}
