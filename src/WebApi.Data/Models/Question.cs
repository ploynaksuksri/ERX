using System;
using System.Collections.Generic;

namespace WebApi.Data.Models
{
    public class Question : BaseEntity
    {
        public string Title { get; set; }
        public int Order { get; set; }
        public List<Choice> Choices { get; set; } = new List<Choice>();

        public bool IsMultipleChoice
        {
            get => Choices.Count > 0;
        }

        public Question(string title)
        {
            Title = title;
        }
    }
}