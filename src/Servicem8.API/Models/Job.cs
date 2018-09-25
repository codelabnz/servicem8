using System;
namespace Servicem8.API.Models
{
    public class Job : IKey
    {
        public Job()
        {
        }

        public Guid uuid { get; set; }
        public int active { get; set; }
        public DateTime edit_date { get; set; }
        public Guid? created_by_staff_uuid { get; set; }
        public DateTime? date { get; set; }
        public Guid? company_uuid { get; set; }
        public String job_address { get; set; }
        public String billing_address { get; set; }
        public String status { get; set; }
        public String job_description { get; set; }
        public String work_done_description { get; set; }
        public Decimal? lng { get; set; }
        public Decimal? lat { get; set; }
        public String generated_job_id { get; set; }
        public DateTime? payment_date { get; set; }
        public DateTime? quote_date { get; set; }
        public DateTime? work_order_date { get; set; }
        public DateTime? completion_date { get; set; }
        public DateTime? unsuccessful_date { get; set; }
        public Guid? queue_uuid { get; set; }
        public DateTime? queue_expiry_date { get; set; }
        public String purchase_order_number { get; set; }
    }
}