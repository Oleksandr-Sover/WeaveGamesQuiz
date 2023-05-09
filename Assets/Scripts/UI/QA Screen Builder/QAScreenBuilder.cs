using TMPro;
using UnityEngine;

namespace UI
{
    public class QAScreenBuilder : MonoBehaviour, IQAScreenBuilder
    {
        IAnswerButtonsBuilder AnswerButtonsBuilder;

        public Date.QuestionAndAnswers qa;

        [SerializeField] TextMeshProUGUI questionText;

        [SerializeField] float delay = 2;
        float delayTimer;

        bool isNextQuestion;

        void Awake()
        {
            AnswerButtonsBuilder = GetComponent<IAnswerButtonsBuilder>();
        }

        void Start()
        {
            delayTimer = delay;
        }

        void Update()
        {
            // The condition is needed to handle the delay before the next question screen starts
            if (isNextQuestion)
                AssembleQuestionScreenWithDelay();
        }

        void AssembleQuestionScreenWithDelay()
        {
            // Wait for the delay and start the next question screen
            if (delayTimer > 0)
                delayTimer -= Time.deltaTime;
            else
            {
                delayTimer = delay;
                isNextQuestion = false;
                AssembleQuestionScreen(qa);
            }
        }

        public void AssembleQuestionScreen(Date.QuestionAndAnswers questionAndAnswers)
        {
            questionText.text = questionAndAnswers.question;
            AnswerButtonsBuilder.SetAnswerButtons(questionAndAnswers);
        }

        public void AssembleNextQuestionScreen(Date.QuestionAndAnswers questionAndAnswer)
        {
            qa = questionAndAnswer;
            // Set the trigger condition for the delay, after which the next question screen will open
            isNextQuestion = true;
            // Show the correct answer until the next question screen starts, after a delay
            AnswerButtonsBuilder.SetIndicationOfCorrectAnswerButtons();
            // Deactivate the buttons so that they cannot be clicked while there is a delay before launching the next question screen
            AnswerButtonsBuilder.DeactivateAnswerButtons();
        }

        public void DeactivateAnswerButtons() => AnswerButtonsBuilder.DeactivateAnswerButtons();
    }
}