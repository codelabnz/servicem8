using System;
namespace Servicem8.API.Models
{
    public class JobActivity : IKey
    {
        public JobActivity()
        {
        }

        public Guid uuid { get; set; }
        public int active { get; set; }
        public DateTime edit_date { get; set; }
        public Guid job_uuid { get; set; }
        public Guid staff_uuid { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string activity_was_scheduled { get; set; }
        public string activity_was_recorded { get; set; }
        public Guid material_uuid { get; set; }
        public DateTime allocated_timestamp { get; set; }

    }
}