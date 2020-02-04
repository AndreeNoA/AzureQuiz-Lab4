using System.Collections.Generic;

namespace AzureQuiz
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int CorrectAnswer { get; set; }
        public string AnswerOne { get; set; }
        public string AnswerTwo { get; set; }
        public string AnswerThree { get; set; }
        public string AnswerFour { get; set; }

    }
}