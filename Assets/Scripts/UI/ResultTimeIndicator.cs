using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ResultTimeIndicator : MonoBehaviour
    {
        [SerializeField] Date.GameMetricsDate gameMetricsDate;

        TextMeshProUGUI resultTimeText;

        void Awake()
        {
            resultTimeText = GetComponent<TextMeshProUGUI>();
        }

        void OnEnable()
        {
            resultTimeText.text = gameMetricsDate.testTime;
        }
    }
}