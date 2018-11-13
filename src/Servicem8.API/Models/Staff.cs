using System;
namespace Servicem8.API.Models
{
    public class Staff : IKey
    {
        public Guid uuid { get; set; }
        public int active { get; set; }
        public DateTime edit_date { get; set; }
        public string first { get; set; }
        public string last { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public Guid security_role_uuid { get; set; }

    }
}
