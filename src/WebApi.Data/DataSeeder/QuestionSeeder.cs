using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Models;
using WebApi.Data.Repositories;

namespace WebApi.Data.DataSeeder
{
    public class QuestionSeeder : IDataSeeder
    {
        private readonly IQuestionRepository _repository;

        private List<Question> _questions = new List<Question>()
        {
            new Question(QuestionConstants.Title){ Order = 1},
            new Question(QuestionConstants.FirstName){ Order = 2},
            new Question(QuestionConstants.LastName){ Order = 3},
            new Question(QuestionConstants.DateOfBirth){ Order = 4},
            new Question(QuestionConstants.CountryOfResidence){ Order = 5},
            new Question(QuestionConstants.HouseAddress){ Order = 6},
            new Question(QuestionConstants.WorkAddress){ Order = 7},
            new Question(QuestionConstants.Occupation){ Order = 8},
            new Question(QuestionConstants.JobTitle){ Order = 9},
            new Question(QuestionConstants.BusinessType){ Order = 10}
        };

        public QuestionSeeder(IQuestionRepository repository)
        {
            _repository = repository;
        }

        public async Task SeedData()
        {
            foreach (var question in _questions)
            {
                await AddNewTypeAsync(question);
            }

            await _repository.SaveChanges();
        }

        private async Task AddNewTypeAsync(Question question)
        {
            var existingType = await _repository.GetByTitle(question.Title);
            if (existingType == null)
            {
                await _repository.Add(question, false);
            }
        }
    }
}