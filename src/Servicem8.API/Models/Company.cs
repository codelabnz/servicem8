using System;
using Servicem8.API.Models;

namespace Servicem8.API.Models
{
    public class Company : IKey
    {
        public Company()
        {
           
        }

        public Guid uuid { get; set; }
        public String name { get; set; }
        public int active { get; set; }
        public DateTime edit_date { get; set; }
        public String website { get; set; }
        public String abn_number { get; set; }
        public int is_individual { get; set; }
        public String address_street { get; set; }
        public String address_city { get; set; }
        public String address_state { get; set; }
        public String address_postcode { get; set; }
        public String address_country { get; set; }
        public String fax_number { get; set; }
        public String address { get; set; }
        public String billing_address { get; set; }
       
    }
}
