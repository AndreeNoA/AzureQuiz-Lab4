using System;
using System.Collections.Generic;
using System.Text;

namespace AzureQuiz
{
    public class Menu
    {

        public void StartMenu(ConnectionContext connection)
        {
            Login login = new Login(connection);
            Player currentPlayer = login.PickPlayer();
            PlayGame play = new PlayGame(connection, currentPlayer);
            Create createQA = new Create(connection);
            PrintQuestions printQuestions = new PrintQuestions(connection);

            bool quitQuiz = false;
            while (quitQuiz == false)
            {
                Console.Clear();
                Console.WriteLine("What do you want to do?\n\nPress 1 to play.\nPress 2 to create questions.\nPress 3 to see all questions.\nPress 4 to exit.");
                var input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        play.PlayTheGame();
                        break;
                    case ConsoleKey.D2:
                        createQA.CreateQuestion();
                        break;
                    case ConsoleKey.D3:
                        printQuestions.PrintAllQuestions();
                        break;
                    case ConsoleKey.D4:
                        quitQuiz = true;
                        break;
                }
            }
        }
    }
}
