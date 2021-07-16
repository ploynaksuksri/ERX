using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class AnswerCreateDto
    {
        public int QuestionId { get; set; }
        public string WrittenAnswer { get; set; }
        public int ChoiceId { get; set; }
    }
}