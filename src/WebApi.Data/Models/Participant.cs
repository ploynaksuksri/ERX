using System.Collections.Generic;

namespace WebApi.Data.Models
{
    public class Participant : BaseEntity
    {
        public Question LastQuestion { get; set; }
        public List<Answer> Answers { get; set; }
    }
}