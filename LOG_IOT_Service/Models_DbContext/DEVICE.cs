using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LOG_IOT_Service.Models_DbContext
{
    public class DEVICE
    {
        [Key]
        public int DEVICE_ID { get; protected set; }
        public int? USER_ID { get; internal set; }
        public string? NAME { get; set; }
        public string? IPV4 { get; internal set; }
    }
}
