﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Servicem8.API.Services;
using Servicem8.API.Models;

namespace Servicem8.API.Resources
{
    public class JobResource : Resource
    {
        public JobResource(IClientExecutionService client) : base(client) { }

        private const string ListUrl = "/job.json";
        private const string QuoteUrl = "/job.json?$filter=status%20eq%20'Quote'";
        private const string ByIdUrl = "/job.json?$filter=uuid%20eq%20'{id}'";
        private const string CreateUrl = "/job.json";
        private const string UpdateUrl = "/job/{id}.json";
        private const string DeleteByIdUrl = "/job/{id}.json";

        public Task<List<Job>> List()
        {
            return Client.ExecuteList<Job>(ListUrl);
        }

        public Task<List<Job>> Quotes()
        {
            return Client.ExecuteList<Job>(QuoteUrl);
        }

        public Task<Job> ById(Guid id)
        {
            return Client.ExecuteSingle<Job>(ByIdUrl, id);
        }

        public Task Create(Job model)
        {
            return Client.ExecutePayload(CreateUrl, model);
        }

        public Task Update(Job model)
        {
            return Client.ExecutePayload(UpdateUrl, model, model.uuid);
        }

        public Task Delete(Job model)
        {
            return Client.ExecuteDelete(DeleteByIdUrl, model.uuid);
        }
    }
}
