using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AzureQuiz
{
    public class Create
    {
        private ConnectionContext connection;
        public Create(ConnectionContext connection)
        {
            this.connection = connection;
        }

        public void CreateQuestion()
        {
            var query = from question in connection.Questions
                        select question;

            var quest = new Question
            {
                Id = query.Count()+1,
                QuestionText = NewQuestion(),
                AnswerOne = NewAnswer(1),
                AnswerTwo = NewAnswer(2),
                AnswerThree = NewAnswer(3),
                AnswerFour = NewAnswer(4),
                CorrectAnswer = CorrectAnswer()
            };
            connection.Questions.Add(quest);            
            connection.SaveChanges();
        }

        public int CorrectAnswer()
        {
            Console.WriteLine("Which answer is the correct one?");
            var input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    return 1;
                case ConsoleKey.D2:
                    return 2;
                case ConsoleKey.D3:
                    return 3;
                case ConsoleKey.D4:
                    return 4;
                default:
                    return 5;
            }
        }
        public string NewQuestion()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Write a question");
                string input = Console.ReadLine().Trim();
                if (input == "")
                {
                    Console.WriteLine("You have to write something");
                }
                else
                {
                    return input;
                }
            }
        }

        public string NewAnswer(int number)
        {
            Console.WriteLine("Option number " + number);
            string input = Console.ReadLine();
            return input;
        }

    }
}
