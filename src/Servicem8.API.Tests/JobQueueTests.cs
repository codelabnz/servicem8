using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Servicem8.API.Tests
{
    [TestClass]
    public class JobQueueTests : IntegrationTestsAbstract
    {
        public JobQueueTests()
        {
        }

        [TestMethod]
        public async Task CanFetchJobQueues()
        {


            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var jobQueues = await servicem8Client.JobQueues.List();

            Assert.IsTrue(jobQueues.Count > 0);

        }

    }
}
