using System.Collections.Generic;

namespace WebApi.Data.Models
{
    public class Question : BaseEntity
    {
        public string Title { get; set; }
        public int Order { get; set; }
        public List<Choice> Choices {get;set;}
        public bool IsMultipleChoice
        {
            get
            {
                return Choices is null || Choices.Count == 0;
            }
        }
    }

    

    
}