using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace AzureQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new ConnectionContext();                        
            connection.Database.EnsureCreated();

            Player currentPlayer = PickPlayer(connection);
            bool quitQuiz = false;
            while (quitQuiz == false)
            {
                Console.Clear();
                Console.WriteLine("What do you want to do?\n\nPress 1 to play.\nPress 2 to create questions.\nPress 3 to see all questions.\nPress 4 to exit.");
                var input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        PlayGame.PlayTheGame(connection, currentPlayer);
                        break;
                    case ConsoleKey.D2:
                        Create.CreateQuestion(connection);
                        break;
                    case ConsoleKey.D3:
                        PrintAllQuestions(connection);
                        break;
                    case ConsoleKey.D4:
                        quitQuiz = true;
                        break;
                }
            }
        }
        public static Player PickPlayer(ConnectionContext connection)
        {
            Console.WriteLine("Welcome to this quiz. Please enter your name");

            string alias = Console.ReadLine();
            //Query to look if player exist
            var query = from player in connection.Players
                        where player.Name == alias
                        select player;
            
            if (query.Count() >= 1)
            {
                Console.WriteLine("Welcome back");
                Thread.Sleep(2000);
                return query.First();
            }
            else
            {
                Player player = new Player()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = alias,
                    Score = 0
                };
                connection.Players.Add(player);
                connection.SaveChanges();
                return player;                
            }
        }

        public static void PrintAllQuestions(ConnectionContext connection)
        {
            var getAllQuestions = from question in connection.Questions
                                  select question;

            Console.Clear();
            Console.WriteLine("List of questions");
            int count = 1;
            foreach (var question in getAllQuestions)
            {
                Console.WriteLine(count +" "+ question.QuestionText);
                count++;
            }
            Console.WriteLine("\nPress any key to go back to menu");
            Console.ReadKey(true);
        }
     }
}
