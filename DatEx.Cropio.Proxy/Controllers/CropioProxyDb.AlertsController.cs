using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatEx.Cropio.Proxy.Model;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace DatEx.Cropio.Proxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertsController : ODataController    
    {
        private DbContextCropioProxy _dbContext;

        public AlertsController(DbContextCropioProxy dbContext) { _dbContext = dbContext; }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_dbContext.Alerts);
        }

        [EnableQuery]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_dbContext.Alerts.FirstOrDefault(c => c.Id == key));
        }
    }
}
