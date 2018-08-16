using System;
namespace Servicem8.API.Models
{
    public class JobMaterial : IKey
    {
        public Guid uuid { get; set; }
        public int active { get; set; }
        public DateTime edit_date { get; set; }
        public Guid job_uuid { get; set; }
        public Guid material_uuid { get; set; }
        public string name { get; set; }
        public string quantity { get; set; }
        public string price { get; set; }
        public string displayed_amount { get; set; }
        public string displayed_amount_is_tax_inclusive { get; set; }
        public Guid tax_rate_uuid { get; set; }
        public string sort_order { get; set; }
        public string cost { get; set; }
        public string displayed_cost { get; set; }

        public JobMaterial()
        {
        }
    }
}