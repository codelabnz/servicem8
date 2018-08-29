using System;
using Servicem8.API.Services;
using Servicem8.API.Resources;

namespace Servicem8.API
{
    public class Servicem8Client : IApiSettings
    {
        private readonly string _apiUsername;
        private readonly string _apiPassword;
        private readonly string _url;
       
        private readonly IClientExecutionService _executionService;
        private readonly Lazy<CompanyResource> _companies;
        private readonly Lazy<JobResource> _jobs;
        private readonly Lazy<MaterialResource> _materials;
        private readonly Lazy<JobMaterialResource> _jobMaterials;
        private readonly Lazy<AttachmentResource> _attachments;
        private readonly Lazy<JobQueueResource> _jobQueues;
       

        public Servicem8Client(string apiUsername, string apiPassword, string url = null)
        {
            _apiPassword = apiPassword;
            _apiUsername = apiUsername;
            _url = url ?? "https://api.servicem8.com/api_1.0/";

            _executionService = new ClientExecutionService(this);
            _companies = new Lazy<CompanyResource>(() => new CompanyResource(_executionService), true);
            _jobs = new Lazy<JobResource>(() => new JobResource(_executionService), true);
            _materials = new Lazy<MaterialResource>(() => new MaterialResource(_executionService), true);
            _jobMaterials = new Lazy<JobMaterialResource>(() => new JobMaterialResource(_executionService), true);
            _attachments = new Lazy<AttachmentResource>(() => new AttachmentResource(_executionService), true);
            _jobQueues = new Lazy<JobQueueResource>(() => new JobQueueResource(_executionService), true);
        }

        public CompanyResource Companies
        {
            get { return _companies.Value; }
        }

        public JobResource Jobs
        {
            get { return _jobs.Value; }
        }

        public MaterialResource Materials
        {
            get { return _materials.Value; }
        }

        public JobMaterialResource JobMaterials
        {
            get { return _jobMaterials.Value; }
        }

        public JobQueueResource JobQueues
        {
            get { return _jobQueues.Value; }
        }

        public AttachmentResource Attachments
        {
            get { return _attachments.Value; }
        }

        public string ApiUsername
        {
            get { return _apiUsername; }
        }

        public string ApiPassword
        {
            get { return _apiPassword; }
        }

        public string Url
        {
            get { return _url; }
        }
    }
}
