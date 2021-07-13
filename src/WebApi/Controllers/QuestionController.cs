using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Core;
using WebApi.Data.Models;
using WebApi.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IQuestionManager _questionManager;

        public QuestionController(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        // GET: api/<QuestionController>
        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return _questionManager.Get();
        }

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<QuestionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QuestionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _questionManager.Delete(id);
        }
    }
}