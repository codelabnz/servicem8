using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Servicem8.API.Tests
{
    [TestClass]
    public class JobActivityTests : IntegrationTestsAbstract
    {
        [TestMethod]
        public async Task CanFetchJobActivities()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var jobActivities = await servicem8Client.JobActivities.List();

            Assert.IsTrue(jobActivities.Count > 0);
        }

        [TestMethod]
        public async Task CanFetchJobActivitiesByJob()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var jobId = Guid.Parse("5a8ab941-8701-4341-8e77-c8df39ccf43e");
            var jobActivities = await servicem8Client.JobActivities.ByJobId(jobId);

            Assert.IsTrue(jobActivities.Count > 0);
        }
    }
}
