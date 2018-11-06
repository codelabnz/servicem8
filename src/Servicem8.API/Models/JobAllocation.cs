using System;
namespace Servicem8.API.Models
{
    public class JobAllocation : IKey
    {
        public JobAllocation()
        {
        }

        public Guid uuid { get; set; }
        public int active { get; set; }
        public DateTime edit_date { get; set; }
        public Guid job_uuid { get; set; }
        public Guid? queue_uuid { get; set; }
        public Guid staff_uuid { get; set; }
        public DateTime allocation_date { get; set; }
        public Guid allocation_window_uuid { get; set; }
        public Guid allocated_by_staff_uuid { get; set; }
        public DateTime allocated_timestamp { get; set; }
        public DateTime expiry_timestamp { get; set; }
        public DateTime read_timestamp { get; set; }
        public DateTime completion_timestamp { get; set; }
        public string estimated_duration { get; set; }
        public string revised_duration { get; set; }
        public string sort_priority { get; set; }
        public string requires_acceptance { get; set; }
        public string acceptance_status { get; set; }
        public DateTime acceptance_timestamp { get; set; }
    }

}
