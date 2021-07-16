using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Helper;
using WebApi.Data.Models;
using WebApi.Data.Repositories;

namespace WebApi.Core
{
    public class AnswerManager : IAnswerManager
    {
        private IAnswerRepository _answerRepository;

        public AnswerManager(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<Answer> Add(Answer answer)
        {
            var result = await _answerRepository.Add(answer);
            return result;
        }

        public string GetCsv()
        {
            var csv = AnswerHelper.GenerateCsv(new List<Answer>());
            return csv;
        }
    }
}