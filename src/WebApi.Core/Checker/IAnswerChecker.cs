using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.Checker
{
    public interface IAnswerChecker
    {
        bool IsValid(string answer);
    }
}