using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class QuestionEditDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ChoiceEditDto> Choices { get; set; }
    }
}