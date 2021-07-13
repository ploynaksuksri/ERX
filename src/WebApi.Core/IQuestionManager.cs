using System.Collections.Generic;
using WebApi.Data.Models;

namespace WebApi.Core
{
    public interface IQuestionManager
    {
        IList<Question> Get();
        Question Add(Question question);
        void Update(Question question);
        void Delete(int id);

    }
}