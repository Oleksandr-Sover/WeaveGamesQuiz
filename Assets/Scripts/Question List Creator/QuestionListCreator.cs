using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class QuestionListCreator : MonoBehaviour, IQuestionListCreator
    {
        [SerializeField] Date.QuestionsAndAnswers questionsAndAnswers;

        readonly List<Date.QuestionAndAnswers> tempListOfQuestions = new();

        [SerializeField] int numberOfQuestions = 10;

        [SerializeField] bool randomListOfQuestions;

        // Create a list of questions for the test from a list of existing questions
        public void CreateListOfQuestions(List<Date.QuestionAndAnswers> questionsForQuiz)
        {
            if (randomListOfQuestions)
                CreateRandomListOfQuestions(questionsForQuiz);
            else
                CreateSequentialListOfQuestions(questionsForQuiz);
        }

        public void CreateSequentialListOfQuestions(List<Date.QuestionAndAnswers> questionsForQuiz)
        {
            // Check a sufficient number of questions for the test
            if (questionsAndAnswers.arrayOfQuestionsAndAnswers.Length >= numberOfQuestions)
            {
                questionsForQuiz.Clear();

                // Fill out a list of questions for the test
                for (int i = 0; i < numberOfQuestions; i++)
                    questionsForQuiz.Add(questionsAndAnswers.arrayOfQuestionsAndAnswers[i]);
            }
            else
                Debug.LogError("The number of questions must be at least " + numberOfQuestions);
        }

        public void CreateRandomListOfQuestions(List<Date.QuestionAndAnswers> questionsForQuiz)
        {
            // Check a sufficient number of questions for the test
            if (questionsAndAnswers.arrayOfQuestionsAndAnswers.Length >= numberOfQuestions)
            {
                questionsForQuiz.Clear();

                // Fill in the temporary list of questions
                tempListOfQuestions.AddRange(questionsAndAnswers.arrayOfQuestionsAndAnswers);

                while (questionsForQuiz.Count < numberOfQuestions)
                {
                    // Determine the number of a random question from the temporary list
                    int randomQuestion = Random.Range(0, tempListOfQuestions.Count);
                    questionsForQuiz.Add(tempListOfQuestions[randomQuestion]);
                    // Remove the selected question from the temporary list so that the questions are unique
                    tempListOfQuestions.Remove(tempListOfQuestions[randomQuestion]);
                }
            }
            else
                Debug.LogError("The number of questions must be at least " + numberOfQuestions);
        }
    }
}