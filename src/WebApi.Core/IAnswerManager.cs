using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Core
{
    public interface IAnswerManager
    {
        Task<Answer> Add(Answer answer);

        Task<string> GetCsvAsync();
    }
}