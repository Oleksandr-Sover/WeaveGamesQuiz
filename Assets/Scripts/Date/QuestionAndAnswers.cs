using System;
using System.Collections.Generic;
using UnityEngine;

namespace Date
{
    [Serializable]
    public class QuestionAndAnswers
    {
        [TextArea] public string question;

        public string correctAnswer;

        [Header("Fill in one to three wrong answers (empty fields are ignored)")]
        public string firstWrongAnswer;
        public string secondWrongAnswer;
        public string thirdWrongAnswer;

        // Dictionary of answers where the value-true is the correct answer
        public Dictionary<string, bool> answers = new();
    }
}