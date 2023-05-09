using UnityEngine;

namespace Date
{
    [CreateAssetMenu(fileName = "GameMetricsDate", menuName = "ScriptableObjects/GameMetricsDate", order = 2)]
    public class GameMetricsDate : ScriptableObject
    {
        public int score;
        public int bestScore;
        public int mistakes;
        public int maxMistakes;
        public string testTime;
    }
}