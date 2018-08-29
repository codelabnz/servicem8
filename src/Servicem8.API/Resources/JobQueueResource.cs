using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Servicem8.API.Models;
using Servicem8.API.Services;

namespace Servicem8.API.Resources
{
    public class JobQueueResource : Resource
    {
        public JobQueueResource(IClientExecutionService client) : base(client) { }

        private const string ListUrl = "/queue.json";
     
        public Task<List<JobQueue>> List()
        {
            return Client.ExecuteList<JobQueue>(ListUrl);
        }

    }
}
