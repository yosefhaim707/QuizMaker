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
            // Create an XML doc instance to read the XML file
            XmlDocument xmlDocumentRead = new XmlDocument();
            xmlDocumentRead.Load(filePath);
            XmlNode xmlRoot = xmlDocumentRead.DocumentElement;

            // Create an XML Item node
            
            XmlNode xmlItemNode = xmlDocumentRead.CreateElement("Item");
            xmlRoot.AppendChild(xmlItemNode);
            XmlNode xmlQuestionNode = xmlDocumentRead.CreateElement("Question");
            xmlQuestionNode.InnerText = question;
            xmlItemNode.AppendChild(xmlQuestionNode);
            XmlNode xmlAnswerNode = xmlDocumentRead.CreateElement("Answer");
            xmlAnswerNode.InnerText = answer;
            xmlItemNode.AppendChild(xmlAnswerNode);

            // Add the item to the root
            xmlRoot.AppendChild(xmlItemNode);
            xmlDocumentRead.Save(filePath);


        }

        public List<XmlNode> ShowQuestions()
        {
            // Create an XML doc instance to read the XML file
            XmlDocument xmlDocumentRead = new XmlDocument();
            xmlDocumentRead.Load(filePath);
            XmlNode xmlRoot = xmlDocumentRead.DocumentElement;

            // Iterate over all Item nodes
            int questionCount = 0;
            List<XmlNode> questionNodeList = new List<XmlNode>();
            foreach(XmlNode child in xmlRoot.ChildNodes)
            {
                Console.WriteLine($"Question number {questionCount} : {child["Question"].InnerText}");
                Console.WriteLine($"Answer : {child["Answer"].InnerText}");
                questionNodeList.Add( child );
                questionCount++;
            }
            return questionNodeList;
        }

        public bool ValidAnswer(int questionIndex, string answer, List<XmlNode> questionNodeList)
        {
            if(answer == questionNodeList[questionIndex]["Answer"].InnerText)
            {
                return true;
            }
            return false;
        }
    }
}
