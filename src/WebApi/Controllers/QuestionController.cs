﻿using AutoMapper;
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
        private readonly IQuestionManager _questionManager;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionManager questionManager,
            IMapper mapper)
        {
            _questionManager = questionManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Question>> Get()
        {
            return await _questionManager.GetAsync();
        }

        [HttpGet("{participantId}")]
        public async Task<ActionResult<Question>> Get(int participantId)
        {
            var question = await _questionManager.GetNextAsync(participantId);
            if (question == null)
                return BadRequest();
            return Ok(question);
        }

        [HttpPost]
        public async Task<ActionResult<Question>> Post([FromBody] QuestionCreateDto question)
        {
            if (question is null)
                return BadRequest();

            if (string.IsNullOrEmpty(question.Title))
                return BadRequest();

            var questionToAdd = _mapper.Map<Question>(question);
            var result = await _questionManager.AddAsync(questionToAdd);

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
            existingQuestion.Choices = _mapper.Map<List<Choice>>(question.Choices); ;
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