using Date;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace GameLogic
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameMetricsDate gameMetricsDate;

        IQuestionListCreator QuestionListCreator;
        IQAScreenBuilder QAScreenBuilder;
        IScreenActivator ScreenActivator;

        readonly List<QuestionAndAnswers> questionsForQuiz = new();

        public int questionNumber = 0;
        int numberOfQuestions;

        void Awake()
        {
            QuestionListCreator = GetComponent<IQuestionListCreator>();
            QAScreenBuilder = GetComponentInChildren<IQAScreenBuilder>();
            ScreenActivator = GetComponentInChildren<IScreenActivator>();
        }

        void Start()
        {
            QuestionListCreator.CreateListOfQuestions(questionsForQuiz);
            QAScreenBuilder.AssembleQuestionScreen(questionsForQuiz[questionNumber]);
            questionNumber++;
            numberOfQuestions = questionsForQuiz.Count;
        }

        void Update()
        {
            // When the number of errors exceeds the maximum value, we display the result failed Screen
            if (gameMetricsDate.mistakes > gameMetricsDate.maxMistakes)
                ScreenActivator.TurnOnResultFailedScreen();
        }

        // The method is called when clicking on the buttons with answers
        public void GoToNextQuestion()
        {
            if (questionNumber < numberOfQuestions)
            {
                // Display the next question on the screen
                QAScreenBuilder.AssembleNextQuestionScreen(questionsForQuiz[questionNumber]);
                questionNumber++;
            }
            // When all the questions asked are completed, display the result congrats screen
            else if (questionNumber >= numberOfQuestions)
            {
                ScreenActivator.TurnOnResultCongratsScreen();
                // Deactivate the buttons so that they cannot be clicked while there is a delay before launching the next screen
                QAScreenBuilder.DeactivateAnswerButtons();
            }
        }
    }
}