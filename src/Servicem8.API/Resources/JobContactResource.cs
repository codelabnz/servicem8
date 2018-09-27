using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Servicem8.API.Services;
using Servicem8.API.Models;

namespace Servicem8.API.Resources
{
    public class JobContactResource : Resource
    {
        public JobContactResource(IClientExecutionService client) : base(client) { }

        private const string ListUrl = "/jobcontact.json";
        private const string ByIdUrl = "/jobcontact/{id}.json";
        private const string CreateUrl = "/jobcontact.json";
        private const string UpdateUrl = "/jobcontact/{id}.json";
        private const string DeleteByIdUrl = "/jobcontact/{id}.json";
        private const string ByJobId = "/jobcontact.json?%24filter=job_uuid%20eq%20'{0}'";

        public Task<List<JobContact>> List()
        {
            return Client.ExecuteList<JobContact>(ListUrl);
        }

        public Task<List<JobContact>> ByJob(Guid jobId)
        {
            return Client.ExecuteList<JobContact>(string.Format(ByJobId, jobId));
        }

        public Task<JobContact> ById(Guid id)
        {
            return Client.ExecuteSingle<JobContact>(ByIdUrl, id);
        }

        public Task Create(JobContact model)
        {
            return Client.ExecutePayload(CreateUrl, model);
        }

        public Task Update(JobContact model)
        {
            return Client.ExecutePayload(UpdateUrl, model, model.uuid);
        }

        public Task Delete(JobContact model)
        {
            return Client.ExecuteDelete(DeleteByIdUrl, model.uuid);
        }
    }
}
