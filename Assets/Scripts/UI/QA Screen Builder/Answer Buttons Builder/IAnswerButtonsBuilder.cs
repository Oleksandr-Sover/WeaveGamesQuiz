
namespace UI
{
    public interface IAnswerButtonsBuilder
    {
        void SetAnswerButtons(Date.QuestionAndAnswers questionAndAnswers);
        void SetIndicationOfCorrectAnswerButtons();
        void DeactivateAnswerButtons();
    }
}