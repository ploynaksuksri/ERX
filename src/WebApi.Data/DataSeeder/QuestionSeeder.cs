using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Data.Models;
using WebApi.Data.Repositories;

namespace WebApi.Data.DataSeeder
{
    public class QuestionSeeder : BaseDataSeeder<Question>
    {
        private List<Question> _questions = new List<Question>()
        {
            new Question("Title"),
            new Question("First name"),
            new Question("Last name"),
            new Question("Date of birth"),
            new Question("Country of residence"),
            new Question("House Address"),
            new Question("Work Address"),
            new Question("Occupation"),
            new Question("Job Title"),
            new Question("Business Type")
        };

        public QuestionSeeder(IQuestionRepository repository) : base(repository)
        {
        }

        public void SeedData()
        {
            foreach (var question in _questions)
            {
                AddNewType(question);
            }

            _repository.SaveChanges();
        }

        private void AddNewType(Question question)
        {
            var existingType = _repository.Get(question.Id);
            if (existingType == null)
            {
                _repository.Add(question, false);
            }
        }
    }
}