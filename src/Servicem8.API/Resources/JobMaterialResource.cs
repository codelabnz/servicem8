using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Servicem8.API.Models;
using Servicem8.API.Services;

namespace Servicem8.API.Resources
{
	public class JobMaterialResource : Resource
    {
        public JobMaterialResource(IClientExecutionService client) : base(client) { }

        private const string ListUrl = "/jobmaterial.json";
        private const string JobUrl = "/jobmaterial.json?$filter=job_uuid%20eq%20'{0}'";
        private const string ByIdUrl = "/jobmaterial.json?$filter=uuid%20eq%20'{id}'";
        private const string CreateUrl = "/jobmaterial.json";
        private const string UpdateUrl = "/jobmaterial/{id}.json";
        private const string DeleteByIdUrl = "/jobmaterial/{id}.json";

        public Task<List<JobMaterial>> List()
        {
            return Client.ExecuteList<JobMaterial>(ListUrl);
        }

        public Task<List<JobMaterial>> ByJob(Guid jobId)
        {
            return Client.ExecuteList<JobMaterial>(string.Format(JobUrl, jobId));
        }

        public Task<JobMaterial> ById(Guid id)
        {
            return Client.ExecuteSingle<JobMaterial>(ByIdUrl, id);
        }

        public Task Create(JobMaterial model)
        {
            return Client.ExecutePayload(CreateUrl, model);
        }

        public Task Update(JobMaterial model)
        {
            return Client.ExecutePayload(UpdateUrl, model, model.uuid);
        }

        public Task Delete(JobMaterial model)
        {
            return Client.ExecuteDelete(DeleteByIdUrl, model.uuid);
        }
    }
}
