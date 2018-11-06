using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicem8.API.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Servicem8.API.Tests
{
    [TestClass]
    public class JobTests : IntegrationTestsAbstract
    {
        [TestMethod]
        public async Task CanFetchJobs()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var jobs = await servicem8Client.Jobs.List();

            Assert.IsTrue(jobs.Count > 0);

            var job = jobs.Find(s => s.generated_job_id == "51");
        }

        [TestMethod]
        public async Task CanFetchQuotes()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var quotes = await servicem8Client.Jobs.Quotes();

            Assert.IsTrue(quotes.Count > 0);
            foreach (var quote in quotes) 
            {
                Assert.IsTrue(quote.status == "Quote");
            }
        }

        [TestMethod]
        public async Task CanFetchByStatuses()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var statuses = new List<string>() { "Quote", "Work Order" };

            var jobs = await servicem8Client.Jobs.Statuses(statuses);

            Assert.IsTrue(jobs.Count > 0);
           
        }

        [TestMethod]
        public void CanCreateNewQuote()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);


            var newJobId = Guid.NewGuid();

            var newJob = new Job()
            {
                uuid = newJobId,
                active = 1,
                job_address = string.Format("newAddress{0}", newJobId),
                billing_address = string.Format("newBillingAddress{0}", newJobId),
                date = DateTime.Now,
                job_description = string.Format("jobDesc{0}", newJobId),
                work_order_date = DateTime.Now,
                status = "Quote"
            };

            var result = servicem8Client.Jobs.Create(newJob);
            result.Wait();

            Assert.IsNull(result.Exception);


        }

        [TestMethod]
        public async Task CanDeleteJob()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var jobId = Guid.Parse("82df202f-ac5b-4f49-942f-437cd4dcb29f");
            var job = await servicem8Client.Jobs.ById(jobId);

            Assert.IsNotNull(job);

            var result = servicem8Client.Jobs.Delete(job);
            result.Wait();

            Assert.IsNull(result.Exception);
        }

    }
}
