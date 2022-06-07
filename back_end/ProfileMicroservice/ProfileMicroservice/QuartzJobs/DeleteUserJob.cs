using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMicroservice.QuartzJobs
{
    public class DeleteUserJob : IJob
    {
        private readonly ILogger<DeleteUserJob> _logger;
        private readonly IServiceProvider _provider;
        public DeleteUserJob(IServiceProvider provider, ILogger<DeleteUserJob> logger)
        {
            _provider = provider;
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            using (var scope = _provider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<DBContext>();

                var overdueUsers = dbContext.Users.Where(p => p.DeletionTime < DateTime.UtcNow).ToArray();
               
                if (overdueUsers != null)
                {
                    foreach (var user in overdueUsers)
                    {
                        dbContext.Users.Remove(user);
                        _logger.LogInformation("Deleted User");
                    }
                }
                dbContext.SaveChanges();
            }

            return Task.CompletedTask;
        }
    }
}

