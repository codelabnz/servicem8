using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Servicem8.API.Models;
using Servicem8.API.Services;

namespace Servicem8.API.Resources
{
    public class StaffResource : Resource
    {
        public StaffResource(IClientExecutionService client) : base(client) { }

        private const string ListUrl = "/staff.json";

        public Task<List<Staff>> List()
        {
            return Client.ExecuteList<Staff>(ListUrl);
        }
    }
}
