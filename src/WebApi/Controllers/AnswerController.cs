using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core;
using WebApi.Core.Checker;
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
        private IEnumerable<IAnswerChecker> _answerCheckers;

        public AnswerController(
            IServiceProvider serviceProvider,
            IAnswerManager answerManager,
            IQuestionManager questionManager)
        {
            _answerManager = answerManager;
            _questionManager = questionManager;
            _answerCheckers = serviceProvider.GetServices<IAnswerChecker>();
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
            answer.Participant = answerDto.PariticipantId == 0 ? null :
                new Participant() { Id = answerDto.PariticipantId, LastQuestion = question };
            answer.Question = question;

            var isAnswerValid = true;

            if (question.IsMultipleChoice)
            {
                var selectedChoice = question.Choices.FirstOrDefault(e => e.Id == answerDto.ChoiceId);
                if (selectedChoice == null)
                    return BadRequest();
                answer.Choice = selectedChoice;
                isAnswerValid = CheckAnswer(answer);
            }
            else
            {
                if (string.IsNullOrEmpty(answerDto.WrittenAnswer))
                    return BadRequest();
                answer.WrittenAnswer = answerDto.WrittenAnswer;
                isAnswerValid = CheckAnswer(answer);
            }

            if (!isAnswerValid)
                return BadRequest();

            var result = await _answerManager.Add(answer);
            return result;
        }

        #region private methods

        private bool CheckAnswer(Answer answer)
        {
            foreach (var checker in _answerCheckers)
            {
                if (!checker.IsValid(answer))
                    return false;
            }
            return true;
        }

        #endregion private methods
    }
}