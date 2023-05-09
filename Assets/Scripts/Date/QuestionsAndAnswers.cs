using UnityEngine;

namespace Date
{
    [CreateAssetMenu(fileName = "QADate", menuName = "ScriptableObjects/QADate", order = 1)]
    public class QuestionsAndAnswers : ScriptableObject
    {
        [Header("Complete at least 10 questions")]
        public QuestionAndAnswers[] arrayOfQuestionsAndAnswers;
    }
}