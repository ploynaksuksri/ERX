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
            var result = await _answerRepository.Add(answer, true);
            return result;
        }

        public async Task<string> GetCsvAsync()
        {
            var answers = await _answerRepository.GetAll();
            var csv = AnswerHelper.GenerateCsv(answers);
            return csv;
        }
    }
}