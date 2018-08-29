using System;
namespace Servicem8.API.Models
{
    public class JobQueue : IKey
    {
        public JobQueue()
        {
        }

        public Guid uuid { get; set; }
        public int active { get; set; }
        public DateTime edit_date { get; set; }
        public string name { get; set; }
        public int default_timeframe { get; set; }
        public string subscribed_staff { get; set; }
      
    }
}
