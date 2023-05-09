using System.Text;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] Date.GameMetricsDate gameMetricsDate;

        [SerializeField] TextMeshProUGUI secondsText;
        [SerializeField] TextMeshProUGUI minutesText;

        readonly StringBuilder stringBuilder = new();

        readonly string zero = "0";
        readonly string doubleZero = "00";
        readonly string delimiter = ":";

        float timer;

        int seconds;
        int preSeconds;
        int minutes;

        bool startTiming;

        void Start()
        {
            timer = 0;
            seconds = 0;
            minutes = 0;
        }

        void OnEnable()
        {
            startTiming = true;
        }

        void OnDisable()
        {
            startTiming = false;
            WriteDownTime();
        }

        void Update()
        {
            // When the test starts, a timer is started
            if (startTiming)
                HandleTime();
        }

        void HandleTime()
        {
            timer += Time.deltaTime;
            seconds = (int)timer;

            // The condition is necessary so as not to cause processing every frame
            if (seconds != preSeconds)
            {
                preSeconds = seconds;

                // As long as the value is less than 10, add 0 in front of this value
                if (seconds < 10)
                {
                    stringBuilder.Clear();
                    stringBuilder.Append(zero); // add 0 in front of this value
                    stringBuilder.Append(seconds.ToString());
                    secondsText.text = stringBuilder.ToString();
                }
                else if (seconds >= 60)
                {
                    timer = 0;
                    seconds = 0;
                    minutes += 1;

                    // When the value reaches 60 we assign it 00
                    secondsText.text = doubleZero;

                    // As long as the value is less than 10, add 0 in front of this value
                    if (minutes < 10)
                    {
                        stringBuilder.Clear();
                        stringBuilder.Append(zero); // add 0 in front of this value
                        stringBuilder.Append(minutes.ToString());
                        minutesText.text = stringBuilder.ToString();
                    }
                    else
                        minutesText.text = minutes.ToString();
                }
                else
                    secondsText.text = seconds.ToString();
            }
        }

        void WriteDownTime()
        {
            stringBuilder.Clear();

            // As long as the value is less than 10, add 0 in front of this value
            if (minutes < 10)
            {
                stringBuilder.Append(zero); // add 0 in front of this value
                stringBuilder.Append(minutes.ToString());
            }
            else
                stringBuilder.Append(minutes.ToString());

            stringBuilder.Append(delimiter);

            // As long as the value is less than 10, add 0 in front of this value
            if (seconds < 10)
            {
                stringBuilder.Append(zero); // add 0 in front of this value
                stringBuilder.Append(seconds.ToString());
            }
            else
                stringBuilder.Append(seconds.ToString());

            gameMetricsDate.testTime = stringBuilder.ToString();
        }
    }
}