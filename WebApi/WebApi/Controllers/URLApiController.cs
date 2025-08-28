﻿using Microsoft.AspNetCore.Mvc;



namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class URLAPIController : ControllerBase
    {
        // GET: api/<URLAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<URLAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<URLAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<URLAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<URLAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
