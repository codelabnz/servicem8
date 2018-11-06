using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicem8.API.Models;

namespace Servicem8.API.Tests
{
    [TestClass]
    public class JobAllocationTests : IntegrationTestsAbstract
    {
        [TestMethod]
        public async Task CanFetchJobAllocations()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var jobAllocations = await servicem8Client.JobAllocations.List();

            Assert.IsTrue(jobAllocations.Count > 0);
        }

        [TestMethod]
        public async Task CanFetchJobByIdAllocations()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var jobId = Guid.Parse("53EB6C0D-12EB-4650-AC33-4183579AB260");
            var jobAllocations = await servicem8Client.JobAllocations.ByJob(jobId);

            Assert.IsTrue(jobAllocations.Count > 0);
        }

        [TestMethod]
        public void CanCreateAllocations()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var jobId = Guid.Parse("53EB6C0D-12EB-4650-AC33-4183579AB260");
            var newId = Guid.NewGuid();
            var staffId = Guid.Parse("4150ea27-4992-46c5-9d59-7671f4f5e80b");
            var allocationId = Guid.Parse("13203791-e742-4487-83c7-e74d1bcabefb");

            var jobAllocation = new JobAllocation()
            {
                uuid = newId,
                job_uuid = jobId,
                staff_uuid = staffId,
                active = 1,
                edit_date = DateTime.Now,
                allocation_date = DateTime.Now, 
                allocation_window_uuid = allocationId,
               
                acceptance_status = "0", 
                estimated_duration = "0", requires_acceptance = "0", revised_duration = "0",
                sort_priority = "0",
                 expiry_timestamp = DateTime.Now.AddYears(1)

            };

            var result = servicem8Client.JobAllocations.Create(jobAllocation);
            result.Wait();

            Assert.IsNull(result.Exception);
        }

    }
}
