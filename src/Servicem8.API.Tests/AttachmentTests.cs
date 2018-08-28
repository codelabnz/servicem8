using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Servicem8.API.Tests
{
    [TestClass]
    public class AttachmentTests : IntegrationTestsAbstract
    {
        [TestMethod]
        public async Task CanFetchAttachments()
        {

            var servicem8Client = new Servicem8Client(_apiUsername,
                                                     _apiPassword);

            var attachments = await servicem8Client.Attachments.List();

            Assert.IsTrue(attachments.Count > 0);
        }

        [TestMethod]
        public void CanDownloadAttachment()
        {
            var servicem8Client = new Servicem8Client(_apiUsername,
                                                    _apiPassword);

            var attachmentId = Guid.Parse("9b983876-e941-4c79-b348-3e8934df72cb");
            var attachment = servicem8Client.Attachments.DownloadFile(attachmentId);

            Assert.IsNotNull(attachment);
            Assert.IsTrue(attachment.Length > 0);
        }

        [TestMethod]
        public void CanFetchAttachmentInformation()
        {
            var servicem8Client = new Servicem8Client(_apiUsername,
                                                    _apiPassword);

            var attachmentId = Guid.Parse("9b983876-e941-4c79-b348-3e8934df72cb");
            var attachment = servicem8Client.Attachments.ById(attachmentId);

            Assert.IsNotNull(attachment);
          
        }

        [TestMethod]
        public async Task CanFetchAttachmentsByJob()
        {
            var servicem8Client = new Servicem8Client(_apiUsername,
                                                    _apiPassword);

            var jobId = Guid.Parse("f8843544-c058-42ff-af3f-09e3df9c1d3b");
            var attachments = await servicem8Client.Attachments.ByJobId(jobId);

            foreach (var attachment in attachments)
            {
                Assert.IsTrue(attachment.related_object_uuid == jobId);
            }
        }


    }
}
