using System.Collections.Generic;

namespace WebApi.Dtos
{
    public class QuestionCreateDto
    {
        public string Title { get; set; }
        public List<ChoiceCreateDto> Choices { get; set; }
    }
}