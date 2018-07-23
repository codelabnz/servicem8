using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Servicem8.API.Services;
using Servicem8.API.Models;

namespace Servicem8.API.Resources
{
    public class CompanyResource : Resource
    {
        public CompanyResource(IClientExecutionService client) : base(client) { }

        private const string ListUrl = "/company.json";
        private const string ByIdUrl = "/company.json?$filter=uuid%20eq%20'{id}'";
        private const string CreateUrl = "/company.json";

        public Task<List<Company>> List()
        {
            return Client.ExecuteList<Company>(ListUrl);
        }

        public Task<Company> ById(Guid id)
        {
            return Client.ExecuteSingle<Company>(ByIdUrl, id);
        }

        public Task Save(Company model)
        {
            return Client.ExecutePayload(CreateUrl, model);
        }
    }
}
