using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Servicem8.API.Services;
using Servicem8.API.Models;

namespace Servicem8.API.Resources
{
    public class JobActivityResource : Resource
    {
        public JobActivityResource(IClientExecutionService client) : base(client) { }

        private const string ListUrl = "/jobactivity.json";
        private const string ByJobIdUrl = "/jobactivity.json?%24filter=job_uuid%20eq%20'{0}'";

        public Task<List<JobActivity>> List()
        {
            return Client.ExecuteList<JobActivity>(ListUrl);
        }

        public Task<List<JobActivity>> ByJobId(Guid id)
        {
            return Client.ExecuteList<JobActivity>(string.Format(ByJobIdUrl, id));
        }

       
    }
}
