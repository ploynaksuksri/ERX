using System.Collections.Generic;
using WebApi.Data.Models;
using WebApi.Data.Repositories;

namespace WebApi.Data.DataSeeder
{
    public class ChoiceSeeder : BaseDataSeeder<Choice>, IDataSeeder
    {
        private IQuestionRepository _questionRepository;

        public ChoiceSeeder(IChoiceRepository choiceRepository, IQuestionRepository questionRepository)
            : base(choiceRepository)
        {
            _questionRepository = questionRepository;
        }

        private List<Choice> _titles = new List<Choice>()
        {
            new Choice("Mr."),
            new Choice("Ms."),
            new Choice("Mrs.")
        };

        public void SeedData()
        {
            var titleQuestion = GetQuestion("Title");
            foreach (var title in _titles)
            {
                title.Question = titleQuestion;
                AddNewType(title);
            }

            _repository.SaveChanges();
        }

        private void AddNewType(Choice Choice)
        {
            var existingType = _repository.Get(Choice.Id);
            if (existingType == null)
            {
                _repository.Add(Choice, false);
            }
        }

        private Question GetQuestion(string title)
        {
            return _questionRepository.GetByTitle(title);
        }
    }
}