namespace WebApi.Data.Models
{
    public class Choice : BaseEntity
    {
        public string Title { get; set; }
        public Question Question { get; set; }

        public Choice(string title)
        {
            Title = title;
        }
    }
}