using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Servicem8.API.Services;
using Servicem8.API.Models;

namespace Servicem8.API.Resources
{
    public class MaterialResource : Resource
    {
        public MaterialResource(IClientExecutionService client) : base(client) { }

        private const string ListUrl = "/material.json";
        private const string ByIdUrl = "/material.json?$filter=uuid%20eq%20'{id}'";
        private const string CreateUrl = "/material.json";
        private const string UpdateUrl = "/material/{id}.json";
        private const string DeleteByIdUrl = "/material/{id}.json";

        public Task<List<Material>> List()
        {
            return Client.ExecuteList<Material>(ListUrl);
        }

        public Task<Material> ById(Guid id)
        {
            return Client.ExecuteSingle<Material>(ByIdUrl, id);
        }

        public Task Create(Material model)
        {
            return Client.ExecutePayload(CreateUrl, model);
        }

        public Task Update(Material model)
        {
            return Client.ExecutePayload(UpdateUrl, model, model.uuid);
        }

        public Task Delete(Material model)
        {
            return Client.ExecuteDelete(DeleteByIdUrl, model.uuid);
        }
    }
}
