using System;
namespace Servicem8.API.Models
{
    public class Material : IKey
    {
        public Material()
        {
        }

        public Guid uuid { get; set; }
        public int active { get; set; }
        public DateTime edit_date { get; set; }
        public String name { get; set; }
        public String item_number { get; set; }
        public String price { get; set; }
        public String cost { get; set; }
        public String item_description { get; set; }
        public int quantity_in_stock { get; set; }
        public int price_includes_taxes { get; set; }
        public String use_description_for_invoicing { get; set; }
        public Guid? tax_rate_uuid { get; set; }
        public String barcode { get; set; }
        public int item_is_inventoried { get; set; }
    }
}
