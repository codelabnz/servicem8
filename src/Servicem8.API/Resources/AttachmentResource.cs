using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Servicem8.API.Models;
using Servicem8.API.Services;

namespace Servicem8.API.Resources
{
    public class AttachmentResource : Resource
    {
        public AttachmentResource(IClientExecutionService client) : base(client) { }

        private const string ListUrl = "/attachment.json";
        private const string ByIdUrl = "/attachment/{id}.json";
        private const string ByIdFileUrl = "/attachment/{id}.file";
        private const string ByJobIdUrl = "/attachment.json?%24filter=related_object_uuid%20eq%20'{0}'";

        public Task<List<Attachment>> List()
        {
            return Client.ExecuteList<Attachment>(ListUrl);
        }

        public Task<List<Attachment>> ByJobId(Guid jobId)
        {
            return Client.ExecuteList<Attachment>(string.Format(ByJobIdUrl, jobId));
        }

        public Task<Attachment> ById(Guid id)
        {
            return Client.ExecuteSingle<Attachment>(ByIdUrl, id);
        }

        public byte[] DownloadFile(Guid attachmentId)
        {
            return Client.ExecuteDownload(ByIdFileUrl, attachmentId);
        }

    }
}
