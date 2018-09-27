using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicem8.API.Models;
using System.Threading.Tasks;
using System;

namespace Servicem8.API.Tests
{
    [TestClass]
    public class JobContactTests : IntegrationTestsAbstract
    {
        [TestMethod]
        public async Task CanFetchJobContacts()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var jobContacts = await servicem8Client.JobContacts.List();

            Assert.IsTrue(jobContacts.Count > 0);
        }

        [TestMethod]
        public async Task CanFetchJobContactsByJob()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            Guid jobId = Guid.Parse("648ea5f1-699b-4b23-ba80-2898d2862bbb");

            var jobContacts = await servicem8Client.JobContacts.ByJob(jobId);

            Assert.IsTrue(jobContacts.Count > 0);
        }

        [TestMethod]
        public void CanCreateJobContact()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            Guid jobId = Guid.Parse("648ea5f1-699b-4b23-ba80-2898d2862bbb");
            Guid jobContactId = Guid.NewGuid();

            var jobContact = new JobContact()
            {
                 active = 1,
                 edit_date = DateTime.Now,
                 email = "test@test.com",
                 first = "test",
                 job_uuid = jobId,
                 last = "user",
                 mobile = "123",
                 phone = "456",
                 type = "BILLING",
                 uuid = jobContactId
            };

            var result = servicem8Client.JobContacts.Create(jobContact);
            result.Wait();

            Assert.IsNull(result.Exception);

        }

        [TestMethod]
        public void CanUpdateJobContact()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            Guid jobId = Guid.Parse("648ea5f1-699b-4b23-ba80-2898d2862bbb");
            Guid jobContactId = Guid.Parse("8837a2e2-451b-47e8-9722-b8c1fd095094");

            var jobContact = new JobContact()
            {
                active = 1,
                edit_date = DateTime.Now,
                email = "test@test2.com",
                first = "test",
                job_uuid = jobId,
                last = "user2",
                mobile = "1234",
                phone = "4566",
                type = "BILLING",
                uuid = jobContactId
            };

            var result = servicem8Client.JobContacts.Update(jobContact);
            result.Wait();

            Assert.IsNull(result.Exception);

        }

        [TestMethod]
        public void CanDeleteJobContact()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            Guid jobId = Guid.Parse("648ea5f1-699b-4b23-ba80-2898d2862bbb");
            Guid jobContactId = Guid.Parse("8837a2e2-451b-47e8-9722-b8c1fd095094");

            var jobContact = new JobContact()
            {
                active = 0,
                edit_date = DateTime.Now,
                email = "test@test2.com",
                first = "test",
                job_uuid = jobId,
                last = "user2",
                mobile = "1234",
                phone = "4566",
                type = "BILLING",
                uuid = jobContactId
            };

            var result = servicem8Client.JobContacts.Delete(jobContact);
            result.Wait();

            Assert.IsNull(result.Exception);

        }


    }
}
