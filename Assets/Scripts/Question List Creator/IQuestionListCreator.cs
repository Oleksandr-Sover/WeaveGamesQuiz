using System.Collections.Generic;

namespace GameLogic
{
    public interface IQuestionListCreator
    {
        void CreateListOfQuestions(List<Date.QuestionAndAnswers> questionsForQuiz);
    }
}