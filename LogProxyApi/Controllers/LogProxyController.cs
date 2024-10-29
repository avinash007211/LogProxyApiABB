using LogProxyApi.Data;
using LogProxyApi.Migrations;
using LogProxyApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace LogProxyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[Authorize]
    public class LogProxyController : ControllerBase
    {
        private LogProxyDbContext _dbcontrollerobj;

        public LogProxyController(LogProxyDbContext dbcontroller)
        {
            _dbcontrollerobj = dbcontroller;
        }  


        //GET: api/<LogProxyController>
        [HttpGet]
        public IActionResult GetLogs()
        {
            var display = _dbcontrollerobj.entities;

            if (display == null)
            {
                return BadRequest("Not found");
            }
            else
            {

                return Ok(display);

            }

        }

        [HttpGet("{id}")]

        public IActionResult GetLogs(int id)
        {
            var entity = _dbcontrollerobj.entities.Find(id);

            if (entity == null)
            {
                return BadRequest("Not found");
            }

            else
            {
                return Ok(entity);
            }
        }

        // POST api/<LogProxyController>
        [HttpPost]
        public IActionResult PostLogs([FromBody] LogRequest request)
        {

            var LogProxy = new LogProxy
            {
                Title = request.Title,
                Text = request.Text,
                UserId = request.Properties.UserId,
                Module = request.Properties.Module,
                Severity = request.Properties.Severity,
                RecievedAt = DateTime.UtcNow
            };
            _dbcontrollerobj.entities.Add(LogProxy);
            _dbcontrollerobj.SaveChanges();
            return Ok("Saved the changes");
        }

        [HttpDelete("id")]

        public IActionResult Delete(int id)
        {

            var del = _dbcontrollerobj.entities.Find(id);

            if (del == null)
            {
                return NotFound("No record found");

            }

            else
            {

                _dbcontrollerobj.entities.Remove(del);
                _dbcontrollerobj.SaveChanges();
                return Ok("Record deleted");

            }


        }

    }

}