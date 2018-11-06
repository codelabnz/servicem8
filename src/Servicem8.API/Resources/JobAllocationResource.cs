using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Servicem8.API.Models;
using Servicem8.API.Services;

namespace Servicem8.API.Resources
{
    public class JobAllocationResource : Resource
    {
        public JobAllocationResource(IClientExecutionService client) : base(client) { }

        private const string ListUrl = "/joballocation.json";
        private const string ByIdUrl = "/joballocation/{id}.json";
        private const string CreateUrl = "/joballocation.json";
        private const string UpdateUrl = "/joballocation/{id}.json";
        private const string DeleteByIdUrl = "/joballocation/{id}.json";
        private const string ByJobId = "/joballocation.json?%24filter=job_uuid%20eq%20'{0}'";

        public Task<List<JobAllocation>> List()
        {
            return Client.ExecuteList<JobAllocation>(ListUrl);
        }

        public Task<List<JobAllocation>> ByJob(Guid jobId)
        {
            return Client.ExecuteList<JobAllocation>(string.Format(ByJobId, jobId));
        }

        public Task<JobAllocation> ById(Guid id)
        {
            return Client.ExecuteSingle<JobAllocation>(ByIdUrl, id);
        }

        public Task Create(JobAllocation model)
        {
            return Client.ExecutePayload(CreateUrl, model);
        }

        public Task Update(JobAllocation model)
        {
            return Client.ExecutePayload(UpdateUrl, model, model.uuid);
        }

        public Task Delete(JobAllocation model)
        {
            return Client.ExecuteDelete(DeleteByIdUrl, model.uuid);
        }
    }
}
