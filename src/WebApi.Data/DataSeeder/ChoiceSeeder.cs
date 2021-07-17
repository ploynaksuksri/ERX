using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;
using WebApi.Data.Repositories;

namespace WebApi.Data.DataSeeder
{
    public class ChoiceSeeder : IDataSeeder
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IChoiceRepository _choiceRepository;

        public ChoiceSeeder(IChoiceRepository choiceRepository,
            IQuestionRepository questionRepository)
        {
            _choiceRepository = choiceRepository;
            _questionRepository = questionRepository;
            _countries = GetCountries();
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

        private List<string> _countries = new List<string>();

        public async Task SeedData()
        {
            await SeedTitles();
            await SeedOccupations();
            await SeedCountries();
        }

        #region private

        private async Task SeedTitles()
        {
            var titleQuestion = await GetQuestionAsync("Title");
            foreach (var title in _titles)
            {
                if (titleQuestion.Choices.Exists(e => e.Title == title.Title))
                    continue;

                title.Question = titleQuestion;
                await AddNewAsync(title, titleQuestion);
            }
            await _choiceRepository.SaveChanges();
        }

        private async Task SeedOccupations()
        {
            var occupationQuestion = await GetQuestionAsync("Occupation");
            foreach (var occupation in _occupations)
            {
                if (occupationQuestion.Choices.Exists(e => e.Title == occupation.Title))
                    continue;

                occupation.Question = occupationQuestion;
                await AddNewAsync(occupation, occupationQuestion);
            }
            await _choiceRepository.SaveChanges();
        }

        private async Task SeedCountries()
        {
            var countryQuestion = await GetQuestionAsync("Country of residence");
            foreach (var country in _countries)
            {
                if (countryQuestion.Choices.Exists(e => e.Title == country))
                    continue;

                await AddNewAsync(new Choice(country) { Question = countryQuestion }, countryQuestion, autoSave: true);
            }
            await _choiceRepository.SaveChanges();
        }

        private async Task AddNewAsync(Choice Choice, Question question, bool autoSave = false)
        {
            var existingType = await _choiceRepository.CheckExist(Choice.Title, question.Id);
            if (existingType == null)
            {
                await _choiceRepository.Add(Choice, autoSave);
            }
        }

        private async Task<Question> GetQuestionAsync(string title)
        {
            return await _questionRepository.GetByTitle(title);
        }

        private List<string> GetCountries()
        {
            var countries = new List<string>();
            CultureInfo[] cultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo culture in cultureInfo)
            {
                RegionInfo region = new RegionInfo(culture.LCID);
                if (!countries.Contains(region.EnglishName))
                {
                    countries.Add(region.EnglishName);
                }
            }
            return countries.OrderBy(e => e).ToList();
        }

        #endregion private
    }
}