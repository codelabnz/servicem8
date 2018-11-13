using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Servicem8.API.Tests
{
    [TestClass]
    public class StaffTests : IntegrationTestsAbstract
    {
        public StaffTests()
        {
        }

        [TestMethod]
        public async Task CanFetchStaff()
        {


            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var staff = await servicem8Client.Staff.List();

            Assert.IsTrue(staff.Count > 0);

        }

    }
}
