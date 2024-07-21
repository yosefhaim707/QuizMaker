using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace QuizMaker
{
    internal class QAService : IQAService
    {
        public string filePath;
        public QAService(string filePath)
        {
            this.filePath = filePath;
        }
        // Adds a question from the input in to the XML file
        public void CreateQuestion(string question, string answer)
        {
            // Create a XML node
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode xmlItemNode = xmlDocument.DocumentElement;
            XmlNode xmlQuestionNode = xmlDocument.CreateElement("Question");
            xmlQuestionNode.InnerText = question;
            xmlItemNode.AppendChild(xmlQuestionNode);
            XmlNode xmlAnswerNode = xmlDocument.CreateElement("Answer");
            xmlAnswerNode.InnerText = answer;
            xmlItemNode.AppendChild(xmlAnswerNode);

            // Create a XML doc instance to read the XML file
            XmlDocument xmlDocumentRead = new XmlDocument();
            xmlDocumentRead.LoadXml(filePath);
            XmlNode xmlRoot = xmlDocumentRead.DocumentElement;


        }

        public string ShowQuestions()
        {
            throw new NotImplementedException();
        }

        public bool ValidAnswer(string answer)
        {
            throw new NotImplementedException();
        }
    }
}
