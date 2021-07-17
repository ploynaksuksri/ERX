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
            new Question("Title"){ Order = 1},
            new Question("First name"){ Order = 2},
            new Question("Last name"){ Order = 3},
            new Question("Date of birth"){ Order = 4},
            new Question("Country of residence"){ Order = 5},
            new Question("House Address"){ Order = 6},
            new Question("Work Address"){ Order = 7},
            new Question("Occupation"){ Order = 8},
            new Question("Job Title"){ Order = 9},
            new Question("Business Type"){ Order = 10}
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