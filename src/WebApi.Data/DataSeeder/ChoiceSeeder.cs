using System.Collections.Generic;
using System.Threading.Tasks;
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

        private List<Choice> _occupations = new List<Choice>()
        {
            new Choice("Software engineer"),
            new Choice("Teacher"),
            new Choice("Auditor"),
            new Choice("Doctor"),
            new Choice("Sales manager")
        };

        public async Task SeedData()
        {
            var titleQuestion = await GetQuestionAsync("Title");
            foreach (var title in _titles)
            {
                if (titleQuestion.Choices.Exists(e => e.Title == title.Title))
                    continue;

                title.Question = titleQuestion;
                await AddNewAsync(title);
            }

            var occupationQuestion = await GetQuestionAsync("Occupation");
            foreach (var occupation in _occupations)
            {
                if (occupationQuestion.Choices.Exists(e => e.Title == occupation.Title))
                    continue;

                occupation.Question = occupationQuestion;
                await AddNewAsync(occupation);
            }

            await _repository.SaveChanges();
        }

        private async Task AddNewAsync(Choice Choice)
        {
            var existingType = await _repository.Get(Choice.Id);
            if (existingType == null)
            {
                await _repository.Add(Choice, false);
            }
        }

        private async Task<Question> GetQuestionAsync(string title)
        {
            return await _questionRepository.GetByTitle(title);
        }
    }
}