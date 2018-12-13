using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paramore.Brighter;

namespace BrighterTest.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IAmACommandProcessor _processor;

        // GET api/values
        public ValuesController(IAmACommandProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task Post()
        {
            await _processor.SendAsync(new BlogCommand() {Name = "bob"});
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}