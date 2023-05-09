using UnityEngine;

namespace Date
{
    public class GameMetricsDateSetter : MonoBehaviour
    {
        [SerializeField] GameMetricsDate gameMetricsDate;

        void Start()
        {
            // Updating the best score
            if (gameMetricsDate.score > gameMetricsDate.bestScore)
                gameMetricsDate.bestScore = gameMetricsDate.score;
            
            gameMetricsDate.score = 0;
            gameMetricsDate.mistakes = 0;
        }
    }
}