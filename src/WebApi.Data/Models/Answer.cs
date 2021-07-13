namespace WebApi.Data.Models
{
    public class Answer : BaseEntity
    {
        public Question Question {get;set;}
        public string WrittenAnswer {get;set;}
        public Choice Choice {get;set;}
    }
}