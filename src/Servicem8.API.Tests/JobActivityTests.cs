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

            var jobId = Guid.Parse("53EB6C0D-12EB-4650-AC33-4183579AB260");
            var jobActivities = await servicem8Client.JobActivities.ByJobId(jobId);

            Assert.IsTrue(jobActivities.Count > 0);
        }
    }
}
