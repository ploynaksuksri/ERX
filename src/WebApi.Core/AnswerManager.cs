using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
