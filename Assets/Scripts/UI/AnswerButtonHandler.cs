using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AnswerButtonHandler : MonoBehaviour
    {
        [SerializeField] Date.GameMetricsDate gameMetricsDate;
        [SerializeField] Date.UIDate uIDate;

        Image imageOfButton;

        [HideInInspector] public bool isCorrectAnswer;

        void Awake()
        {
            imageOfButton = GetComponent<Image>();
        }

        public void SetAnswerValues()
        {
            if (isCorrectAnswer)
            {
                gameMetricsDate.score += 1;
                imageOfButton.color = uIDate.correctColor;
            }
            else
            {
                gameMetricsDate.mistakes += 1;
                imageOfButton.color = uIDate.wrongColor;
            }
        }
    }
}