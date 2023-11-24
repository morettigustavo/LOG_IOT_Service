using System.ComponentModel.DataAnnotations;

namespace LOG_IOT_Service.Models_DbContext
{
    public class LOG
    {
        [Key]
        public int LOG_ID { get; set; }
        public int DEVICE_ID { get; set; }
        public DateTime DATETIME { get; set; }
        public string STATUS { get; set; }
    }
}
