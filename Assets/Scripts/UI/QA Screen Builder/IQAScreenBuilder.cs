
namespace UI
{
    public interface IQAScreenBuilder
    {
        void AssembleQuestionScreen(Date.QuestionAndAnswers questionAndAnswers);
        void AssembleNextQuestionScreen(Date.QuestionAndAnswers questionAndAnswer);
        void DeactivateAnswerButtons();
    }
}