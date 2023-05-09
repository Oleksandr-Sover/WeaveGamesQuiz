using UnityEngine;

namespace UI
{
    public class ScreenActivator : MonoBehaviour, IScreenActivator
    {
        [SerializeField] GameObject homeScreen;
        [SerializeField] GameObject gameScreen;
        [SerializeField] GameObject resultScreen;

        [SerializeField] GameObject resultingCongratulations;
        [SerializeField] GameObject resultingFailed;

        [SerializeField] float resultScreenDelay = 2;
        float delayTimer;

        bool isResult;
        bool isCongratsScreen;

        void Start()
        {
            TurnOnHomeScreen();
            delayTimer = resultScreenDelay;
        }

        void Update()
        {
            // The condition is needed to handle the delay before starting the result screen
            if (isResult)
                TurnOnResultScreenWithDelay();
        }

        void TurnOnResultScreenWithDelay()
        {
            // Wait for the delay and start the result screen
            if (delayTimer > 0)
                delayTimer -= Time.deltaTime;
            else
            {
                delayTimer = resultScreenDelay;
                isResult = false;
                
                if (isCongratsScreen)
                    TurnOnResultCongratsScreenAfterDelay();
                else
                    TurnOnResultFailedScreenAfterDelay();
            }
        }

        public void TurnOnHomeScreen()
        {
            homeScreen.SetActive(true);
            gameScreen.SetActive(false);
            resultScreen.SetActive(false);
        }

        public void TurnOnGameScreen()
        {
            homeScreen.SetActive(false);
            gameScreen.SetActive(true);
            resultScreen.SetActive(false);
        }

        public void TurnOnResultCongratsScreen()
        {
            isResult = true;
            isCongratsScreen = true;
        }

        void TurnOnResultCongratsScreenAfterDelay()
        {
            homeScreen.SetActive(false);
            gameScreen.SetActive(false);
            resultScreen.SetActive(true);
            resultingCongratulations.SetActive(true);
            resultingFailed.SetActive(false);
        }

        public void TurnOnResultFailedScreen()
        {
            isResult = true;
            isCongratsScreen = false;
        }

        void TurnOnResultFailedScreenAfterDelay()
        {
            homeScreen.SetActive(false);
            gameScreen.SetActive(false);
            resultScreen.SetActive(true);
            resultingCongratulations.SetActive(false);
            resultingFailed.SetActive(true);
        }
    }
}