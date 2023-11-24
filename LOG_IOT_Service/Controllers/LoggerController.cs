using LOG_IOT_Service.Models_DbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LOG_IOT_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class LoggerController : ControllerBase
    {
        private readonly ILogger<LoggerController> _logger;
        private readonly DbContext _DbContext;

        public LoggerController(ILogger<LoggerController> logger)
        {
            _logger = logger;
            _DbContext = new DbContext();
        }

        [HttpPost]
        public void Logger()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;var ip = HttpContext.Request.Host.Value;

            var Devices = _DbContext.DEVICE.Where(p => p.IPV4.Equals(ip)).ToList();

            Devices.ForEach(p =>
            {
                _DbContext.LOG.Add(new LOG { 
                    DATETIME = DateTime.Now,
                    DEVICE_ID = p.DEVICE_ID,
                    STATUS = "OK"
                });
            });

            _DbContext.SaveChanges();
        }
    }
}