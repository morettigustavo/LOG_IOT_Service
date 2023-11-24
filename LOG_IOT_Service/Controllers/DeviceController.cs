using LOG_IOT_Service.Models_DbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

namespace LOG_IOT_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DeviceController : ControllerBase
    {
        private readonly ILogger<DeviceController> _logger;
        private readonly DbContext _DbContext;

        public DeviceController(ILogger<DeviceController> logger)
        {
            _logger = logger;
            _DbContext = new DbContext();
        }

        [HttpGet]
        public List<DEVICE> Get([FromQuery] DEVICE? _Device)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (_Device.DEVICE_ID == 0 && _Device.NAME == null)
            {
                return _DbContext.DEVICE.Where(p => p.USER_ID.Equals(int.Parse(identity.Claims.FirstOrDefault(p => p.Type.Equals("USER_ID")).Value))).ToList();
            }
            else
            {
                return _DbContext.DEVICE.Where(device => (device.DEVICE_ID == _Device.DEVICE_ID || device.NAME.Equals(_Device.NAME)) && device.USER_ID.Equals(int.Parse(identity.Claims.FirstOrDefault(p => p.Type.Equals("USER_ID")).Value))).ToList();
            }
        }
        [HttpPost]
        public DEVICE Register([FromBody] DEVICE _Device)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            _Device.IPV4 = HttpContext.Request.Host.Value;
            _Device.USER_ID = int.Parse(identity.Claims.FirstOrDefault(p => p.Type.Equals("USER_ID")).Value);
            _DbContext.Add(_Device);
            _DbContext.SaveChanges();

            return _Device;
        }

        [HttpDelete]
        public void Delete([FromBody] DEVICE _Device)
        {
            _DbContext.Remove(_Device);
            _DbContext.SaveChanges();
        }
    }
}