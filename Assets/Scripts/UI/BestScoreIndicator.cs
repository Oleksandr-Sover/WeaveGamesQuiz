using TMPro;
using UnityEngine;

namespace UI
{
    public class BestScoreIndicator : MonoBehaviour
    {
        [SerializeField] Date.GameMetricsDate gameMetricsDate;

        TextMeshProUGUI bestScoreText;

        void Awake()
        {
            bestScoreText = GetComponent<TextMeshProUGUI>();
        }

        void Start()
        {
            bestScoreText.text = gameMetricsDate.bestScore.ToString();
        }
    }
}