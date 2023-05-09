using UnityEngine;

namespace Date
{
    public class AnswersDataSetter : MonoBehaviour
    {
        [SerializeField] QuestionsAndAnswers questionsAndAnswers;

        void Awake()
        {
            // Fill in the dictionary of answers for all questions
            foreach (var qa in questionsAndAnswers.arrayOfQuestionsAndAnswers)
                FillAnswerDictionary(qa);
        }

        void FillAnswerDictionary(QuestionAndAnswers qa)
        {
            qa.answers.Clear();

            // Add the correct answer to the dictionary
            qa.answers.Add(qa.correctAnswer, true);

            AddExistingWrongAnswer(qa, qa.firstWrongAnswer);
            AddExistingWrongAnswer(qa, qa.secondWrongAnswer);
            AddExistingWrongAnswer(qa, qa.thirdWrongAnswer);
        }

        void AddExistingWrongAnswer(QuestionAndAnswers qa, string answer)
        {
            // Checking the string for the absence of a value
            if (answer != "" && answer != " ")
                qa.answers.Add(answer, false);
        }
    }
}