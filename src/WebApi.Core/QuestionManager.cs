using System.Collections.Generic;
using System.Linq;
using WebApi.Data.Models;
using WebApi.Data.Repositories;

namespace WebApi.Core
{
    public class QuestionManager : IQuestionManager
    {
        private IQuestionRepository _questionRepository;
        public QuestionManager(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public Question Add(Question question)
        {
            return _questionRepository.Add(question);
        }

        public void Delete(int id)
        {
            _questionRepository.Delete(id);
        }

        public IList<Question> Get()
        {
            return _questionRepository.GetAll().ToList();
        }

        public void Update(Question question)
        {
            _questionRepository.Update(question);        
        }
    }
}