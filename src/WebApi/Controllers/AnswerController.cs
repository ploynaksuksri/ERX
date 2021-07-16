using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core;
using WebApi.Data.Models;
using WebApi.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private IAnswerManager _answerManager;
        private IQuestionManager _questionManager;

        public AnswerController(IAnswerManager answerManager, IQuestionManager questionManager)
        {
            _answerManager = answerManager;
            _questionManager = questionManager;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _answerManager.GetCsvAsync();
            byte[] barr = Encoding.ASCII.GetBytes(result);
            return File(barr, "application/csv", fileDownloadName: "answer.csv");
        }

        [HttpPost]
        public async Task<ActionResult<Answer>> Post([FromBody] AnswerCreateDto answerDto)
        {
            if (answerDto == null)
                return BadRequest();

            var question = await _questionManager.GetAsync(answerDto.QuestionId);
            if (question == null)
                return BadRequest();

            var answer = new Answer();
            answer.Question = question;
            if (question.IsMultipleChoice)
            {
                var selectedChoice = question.Choices.FirstOrDefault(e => e.Id == answerDto.ChoiceId);
                if (selectedChoice == null)
                    return BadRequest();
                answer.Choice = selectedChoice;
            }
            else
            {
                if (string.IsNullOrEmpty(answerDto.WrittenAnswer))
                    return BadRequest();
                answer.WrittenAnswer = answerDto.WrittenAnswer;
            }

            var result = await _answerManager.Add(answer);
            return result;
        }
    }
}