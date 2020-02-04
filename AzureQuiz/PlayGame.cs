using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AzureQuiz
{
    class PlayGame
    {
        public static void PlayTheGame(ConnectionContext connection, Player currentPlayer)
        {
            //Query to make a loop through all questions
            int questionId = 0;
            var questionCount = from question in connection.Questions
                                select question;

            //Keeping and updating the players score
            var scoreCount = from player in connection.Players
                             where player.Name == currentPlayer.Name
                             select player;

            //Fetch the current question from the db
            var getQuestion = from question in connection.Questions
                              where question.Id == questionId
                              select question;

            while (questionId <= questionCount.Count())
            {


                foreach (var question in getQuestion)
                {
                    Console.Clear();
                    Console.WriteLine($"Your score is {scoreCount.First().Score}\n");
                    Console.WriteLine(question.QuestionText);
                    Console.WriteLine("\n1. " + question.AnswerOne);
                    Console.WriteLine("2. " + question.AnswerTwo);
                    Console.WriteLine("3. " + question.AnswerThree);
                    Console.WriteLine("4. " + question.AnswerFour);

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
                    if (guessOption == question.CorrectAnswer)
                    {
                        scoreCount.First().Score++;
                        connection.SaveChanges();
                    }
                }
                questionId++;
            }
        }
    }
}
