using System;
namespace Servicem8.API.Models
{
    public class Attachment : IKey
    {
        public Attachment() 
        {
        }

        public Guid uuid { get; set; }
        public int active { get; set; }
        public DateTime edit_date { get; set; }
        public string related_object { get; set; }
        public Guid related_object_uuid { get; set; }
        public string attachment_name { get; set; }
        public string file_type { get; set; }
        public Guid created_by_staff_uuid { get; set; }
        public string timestamp { get; set; }
        public string attachment_source { get; set; }
        public string tags { get; set; }
        public int lng { get; set; }
        public int lat { get; set; }
    }
}
