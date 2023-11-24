using System.ComponentModel.DataAnnotations;

namespace LOG_IOT_Service.Models_DbContext
{
    public class USER
    {
        [Key]
        public int USER_ID { get; protected set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string? ROLE { get; internal set; }
    }
}
