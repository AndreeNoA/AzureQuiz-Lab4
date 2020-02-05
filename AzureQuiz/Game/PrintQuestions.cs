using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AzureQuiz
{
    public class PrintQuestions
    {
        private ConnectionContext connection;
        public PrintQuestions(ConnectionContext connection)
        {
            this.connection = connection;
        }

        public void PrintAllQuestions()
        {
            var getAllQuestions = from question in connection.Questions
                                  select question;

            Console.Clear();
            Console.WriteLine("List of questions");
            int count = 1;
            foreach (var question in getAllQuestions)
            {
                Console.WriteLine(count + " " + question.QuestionText);
                count++;
            }
            Console.WriteLine("\nPress any key to go back to menu");
            Console.ReadKey(true);
        }
    }
}
