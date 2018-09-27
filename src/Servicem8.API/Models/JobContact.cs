using System;
namespace Servicem8.API.Models
{
    public class JobContact : IKey
    {
        public Guid uuid { get; set; }
        public int active { get; set; }
        public DateTime edit_date { get; set; }
        public Guid job_uuid { get; set; }
        public string first { get; set; }
        public string last { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string type { get; set; } //can either by JOB or BILLING
        public string is_primary_contact { get; set; }

        public JobContact()
        {
        }
    }
}
