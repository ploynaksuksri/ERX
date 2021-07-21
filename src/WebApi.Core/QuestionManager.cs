using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;
using WebApi.Data.Repositories;

namespace WebApi.Core
{
    public class QuestionManager : IQuestionManager
    {
        private IQuestionRepository _questionRepository;
        private IChoiceRepository _choiceRepository;
        private IParticipantRepository _participantRepository;

        public QuestionManager(IQuestionRepository questionRepository,
            IChoiceRepository choiceRepository,
            IParticipantRepository participantRepository)
        {
            _questionRepository = questionRepository;
            _choiceRepository = choiceRepository;
            _participantRepository = participantRepository;
        }

        public async Task<Question> AddAsync(Question question)
        {
            var result = await _questionRepository.Add(question, autoSave: true);
            foreach (var choice in question.Choices)
            {
                await _choiceRepository.Add(choice);
            }
            return await _questionRepository.Get(result.Id);
        }

        public async Task Delete(Question question)
        {
            await _questionRepository.Delete(question);
        }

        public async Task<IList<Question>> GetAsync()
        {
            return await _questionRepository.GetAll();
        }

        public async Task<Question> GetAsync(int id)
        {
            return await _questionRepository.Get(id);
        }

        public async Task<Question> GetNextAsync(int participantId)
        {
            var nextOrder = 1;
            if (participantId != 0)
            {
                var participant = await _participantRepository.Get(participantId);
                if (participant == null)
                    throw new Exception("The given participant id is not found.");

                nextOrder = participant.LastQuestion.Order + 1;
            }

            return await _questionRepository.GetByOrder(nextOrder);
        }

        public async Task Update(Question question)
        {
            await _questionRepository.Update(question);
        }
    }
}