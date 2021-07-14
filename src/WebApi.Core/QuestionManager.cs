using Microsoft.EntityFrameworkCore;
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

        public QuestionManager(IQuestionRepository questionRepository, IChoiceRepository choiceRepository)
        {
            _questionRepository = questionRepository;
            _choiceRepository = choiceRepository;
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

        public async Task Update(Question question)
        {
            await _questionRepository.Update(question);
        }
    }
}