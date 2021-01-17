using Dapper;
using Dapper.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using orm3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace orm3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        private readonly IConfiguration _config;
        private IDapper _pg;

        public ExportController(IConfiguration config, IDapper pg)
        {
            _config = config;
            _pg = pg;
        }

        // GET: api/<ExportController>
        [HttpGet]
        public IEnumerable<Export> Get()
        {
            return _pg.Query<Export>("select * from exports");
        }

        // GET api/<ExportController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var retVal = await _pg.QueryAsync<Export>("select * from exports where id = @Id", new { id }, enableCache: true, cacheKey: $"export_{id}", cacheExpire: TimeSpan.FromSeconds(100));
            return Ok(retVal.FirstOrDefault());
        }

        // POST api/<ExportController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ExportController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExportController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
