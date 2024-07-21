using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuizMaker
{
    internal interface IQAService
    {
        public void CreateQuestion(string question, string answer);
        public List<XmlNode> ShowQuestions();
        public bool ValidAnswer(int questionIndex, string answer, List<XmlNode> questionNodeList);
    }
}
