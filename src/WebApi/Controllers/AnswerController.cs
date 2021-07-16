using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core;
using WebApi.Data.Models;
using WebApi.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private IAnswerManager _answerManager;

        public AnswerController(IAnswerManager answerManager)
        {
            _answerManager = answerManager;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = _answerManager.GetCsv();
            byte[] barr = Encoding.ASCII.GetBytes(result);
            return File(barr, "application/csv", fileDownloadName: "answer.csv");
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<ActionResult<Answer>> Post([FromBody] Answer answer)
        {
            if (answer == null)
                return BadRequest();

            var result = await _answerManager.Add(answer);
            return result;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}