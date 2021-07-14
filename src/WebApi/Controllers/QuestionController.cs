using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core;
using WebApi.Data.Models;
using WebApi.Data.Repositories;
using WebApi.Dtos;

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

        [HttpGet]
        public async Task<IEnumerable<Question>> Get()
        {
            return await _questionManager.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<Question> Get(int id)
        {
            return await _questionManager.GetAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Question>> Post([FromBody] QuestionCreateDto question)
        {
            if (question is null)
                return BadRequest();

            if (string.IsNullOrEmpty(question.Title))
                return BadRequest();
            var choices = new List<Choice>();
            question.Choices.ForEach(e =>
               {
                   choices.Add(new Choice(e.Title));
               });
            var result = await _questionManager.AddAsync(new Question(question.Title));

            return Created("", result);
        }

        [HttpPut]
        public async Task<ActionResult<Question>> Put([FromBody] QuestionEditDto question)
        {
            if (question is null)
                return BadRequest();

            var existingQuestion = await _questionManager.GetAsync(question.Id);
            if (existingQuestion is null)
                return BadRequest();

            existingQuestion.Title = question.Title;
            var choices = new List<Choice>();
            question.Choices.ForEach(e =>
            {
                choices.Add(new Choice(e.Title) { Id = e.Id });
            });
            existingQuestion.Choices = choices;
            await _questionManager.Update(existingQuestion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingQuestion = await _questionManager.GetAsync(id);
            if (existingQuestion is null)
                return BadRequest();

            await _questionManager.Delete(existingQuestion);
            return NoContent();
        }
    }
}