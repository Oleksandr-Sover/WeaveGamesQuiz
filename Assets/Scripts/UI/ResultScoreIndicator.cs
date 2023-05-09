using TMPro;
using UnityEngine;

namespace UI
{
    public class ResultScoreIndicator : MonoBehaviour
    {
        [SerializeField] Date.GameMetricsDate gameMetricsDate;

        TextMeshProUGUI resultScoreText;

        void Awake()
        {
            resultScoreText = GetComponent<TextMeshProUGUI>();
        }

        void OnEnable()
        {
            resultScoreText.text = gameMetricsDate.score.ToString();
        }
    }
}