using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AzureQuiz
{
    public class PlayGame
    {
        private ConnectionContext connection;
        private Player currentPlayer;
        public PlayGame(ConnectionContext connection, Player currentPlayer)
        {
            this.connection = connection;
            this.currentPlayer = currentPlayer;
        }

        public void PlayTheGame()
        {
            //Query to make a loop through all questions
            int questionId = 1;
            var questionCount = from question in connection.Questions
                                select question;

            //Fetch the current question from the db
            var getQuestion = from question in connection.Questions
                              where question.Id == questionId
                              select question;

            while (questionId <= questionCount.Count())
            {

                    Console.Clear();
                    Console.WriteLine($"Your score is {currentPlayer.Score}\n");
                    Console.WriteLine(getQuestion.First().QuestionText);
                    Console.WriteLine("\n1. " + getQuestion.First().AnswerOne);
                    Console.WriteLine("2. " + getQuestion.First().AnswerTwo);
                    Console.WriteLine("3. " + getQuestion.First().AnswerThree);
                    Console.WriteLine("4. " + getQuestion.First().AnswerFour);

                    var input = Console.ReadKey(true);
                    int guessOption = 0;
                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                            guessOption = 1;
                            break;
                        case ConsoleKey.D2:
                            guessOption = 2;
                            break;
                        case ConsoleKey.D3:
                            guessOption = 3;
                            break;
                        case ConsoleKey.D4:
                            guessOption = 4;
                            break;
                    }
                    if (guessOption == getQuestion.First().CorrectAnswer)
                    {
                        currentPlayer.Score++;
                        connection.SaveChanges();
                    }
                questionId++;
            }
        }
    }
}
