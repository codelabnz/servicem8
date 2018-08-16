using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Servicem8.API.Tests
{
    [TestClass]
    public class JobMaterialTests : IntegrationTestsAbstract
    {
        public JobMaterialTests()
        {
        }

        [TestMethod]
        public async Task CanFetchJobMaterials()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var jobMaterials = await servicem8Client.JobMaterials.List();

            Assert.IsTrue(jobMaterials.Count > 0);
        }

        [TestMethod]
        public async Task CanFetchJobMaterialsByJob()
        {
            var jobId = Guid.Parse("cceda3a1-6d1b-4eeb-86e4-c2f83b73a5d1");

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var jobMaterials = await servicem8Client.JobMaterials.ByJob(jobId);

            Assert.IsTrue(jobMaterials.Count > 0);
        }

        [TestMethod]
        public void CanCreateNewJobMaterial()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);


            var jobId = Guid.Parse("cceda3a1-6d1b-4eeb-86e4-c2f83b73a5d1");
            var materialId = Guid.Parse("eb6b708a-ab8a-4d29-bfd9-581a8addda0b");
            var jobMaterial = new Models.JobMaterial()
            {
                 active = 1,
                 cost = "10.00",
                 displayed_amount = "10.00",
                 edit_date = DateTime.Now,
                 job_uuid = jobId,
                 name = "test",
                 price = "10.00",
                 quantity = "1",
                 tax_rate_uuid = Guid.Empty,
                 uuid = Guid.NewGuid(),
                material_uuid = materialId
            };

            var result = servicem8Client.JobMaterials.Create(jobMaterial);
            result.Wait();

            Assert.IsNull(result.Exception);


        }



    }
}
