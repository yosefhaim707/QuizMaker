using System.Xml;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QAService qAService = new QAService("QandA.xml");
            Console.WriteLine("1 - Create Question. 2 - Answer Question");
            string? firstInput = Console.ReadLine();
            if (firstInput == "1")
            {
                Console.WriteLine("Write The Question Here :");
                string questionInput = Console.ReadLine();
                Console.WriteLine("Write The Answer Here :");
                string answerInput = Console.ReadLine();
                qAService.CreateQuestion(questionInput, answerInput);
            }
            else if (firstInput == "2")
            {
                List<XmlNode> questionList =  qAService.ShowQuestions();
                Console.WriteLine("Pick Your Question By Number:");
                int answerNumber = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Now Answer The Question :");
                string answeredInput = Console.ReadLine();
                bool isCorrect = qAService.ValidAnswer(answerNumber, answeredInput, questionList);
                if (isCorrect)
                {
                    Console.WriteLine("Correct Answer");
                }
                else
                {
                    Console.WriteLine("Incorrect Answer");
                }
            }
            
        }
    }
}
