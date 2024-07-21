using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    internal interface IQAService
    {
        public void CreateQuestion(string question, string answer);
        public string ShowQuestions();
        public bool ValidAnswer(string answer);
    }
}
