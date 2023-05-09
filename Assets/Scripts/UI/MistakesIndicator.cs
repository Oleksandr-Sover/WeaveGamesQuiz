using TMPro;
using UnityEngine;

namespace UI
{
    public class MistakesIndicator : MonoBehaviour
    {
        [SerializeField] Date.GameMetricsDate gameMetricsDate;

        TextMeshProUGUI mistakesText;

        int mistakesValue = 0;

        void Awake()
        {
            mistakesText = GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            if (mistakesValue != gameMetricsDate.mistakes)
            {
                mistakesValue = gameMetricsDate.mistakes;
                mistakesText.text = mistakesValue.ToString();
            }
        }
    }
}