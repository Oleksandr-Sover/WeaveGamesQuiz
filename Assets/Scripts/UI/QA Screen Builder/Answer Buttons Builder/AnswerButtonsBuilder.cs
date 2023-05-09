using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AnswerButtonsBuilder : MonoBehaviour, IAnswerButtonsBuilder
    {
        [SerializeField] Date.UIDate uIDate;

        [SerializeField] GameObject fourthAnswerButton;
        [SerializeField] GameObject thirdAnswerButton;
        [SerializeField] GameObject secondAnswerButton;
        [SerializeField] GameObject firstAnswerButton;

        GameObject correctAnswerButton;

        Button fourthButton;
        Button thirdButton;
        Button secondButton;
        Button firstButton;

        TextMeshProUGUI fourthAnswerButtonText;
        TextMeshProUGUI thirdAnswerButtonText;
        TextMeshProUGUI secondAnswerButtonText;
        TextMeshProUGUI firstAnswerButtonText;

        readonly List<string> tempListOfAnswers = new();

        readonly StringBuilder stringBuilder = new();

        readonly string[] designationsForAnswers = { "d) ", "c) ", "b) ", "a) " };

        int numberOfdesignations;

        void Awake()
        {
            fourthAnswerButtonText = fourthAnswerButton.GetComponentInChildren<TextMeshProUGUI>();
            thirdAnswerButtonText = thirdAnswerButton.GetComponentInChildren<TextMeshProUGUI>();
            secondAnswerButtonText = secondAnswerButton.GetComponentInChildren<TextMeshProUGUI>();
            firstAnswerButtonText = firstAnswerButton.GetComponentInChildren<TextMeshProUGUI>();

            fourthButton = fourthAnswerButton.GetComponent<Button>();
            thirdButton = thirdAnswerButton.GetComponent<Button>();
            secondButton = secondAnswerButton.GetComponent<Button>();
            firstButton = firstAnswerButton.GetComponent<Button>();
        }

        public void SetAnswerButtons(Date.QuestionAndAnswers questionAndAnswers)
        {
            tempListOfAnswers.Clear();
            // Fill in the list of answers from the dictionary
            tempListOfAnswers.AddRange(questionAndAnswers.answers.Keys);

            // Set the number of answer designations based on the number of answers
            SetNumberOfdesignations();

            // Activate the answer buttons based on the number of answers
            ActivateAnswerButtons();

            SetAnswerButton(questionAndAnswers, firstAnswerButton, firstAnswerButtonText);
            SetAnswerButton(questionAndAnswers, secondAnswerButton, secondAnswerButtonText);
            SetAnswerButton(questionAndAnswers, thirdAnswerButton, thirdAnswerButtonText);
            SetAnswerButton(questionAndAnswers, fourthAnswerButton, fourthAnswerButtonText);
        }

        void SetNumberOfdesignations()
        {
            // Set the number of answer designations based on the number of answers
            if (tempListOfAnswers.Count == 4)
                numberOfdesignations = 0;
            else if (tempListOfAnswers.Count == 3)
                numberOfdesignations = 1;
            else if (tempListOfAnswers.Count == 2)
                numberOfdesignations = 2;
        }

        void SetAnswerButton(Date.QuestionAndAnswers questionAndAnswers, GameObject button, TextMeshProUGUI buttonText)
        {
            if (tempListOfAnswers.Count > 1)
            {
                // Randomly determine the number of the answer and set it to the button so that the sequence of answers is unique
                int numberOfAnswer = Random.Range(0, tempListOfAnswers.Count);
                SetAnswerButtonValues(questionAndAnswers, button, buttonText, numberOfAnswer);
            }
            else if (tempListOfAnswers.Count == 1)
                // Assign the last answer to the button
                SetAnswerButtonValues(questionAndAnswers, button, buttonText, 0);
            else
                // Disable buttons for which there are no answers left
                button.SetActive(false);
        }

        void SetAnswerButtonValues(Date.QuestionAndAnswers questionAndAnswers, GameObject button, TextMeshProUGUI buttonText, int numberOfAnswer)
        {
            button.SetActive(true);

            // Set the default color, because when pressed, the color changes according to the answer
            button.GetComponent<Image>().color = uIDate.accentColor;

            // Set the button type to correct or incorrect answer
            SetAnswerButtonType(questionAndAnswers, button, numberOfAnswer);

            SetAnswerButtonText(buttonText, numberOfAnswer);
        }

        void SetAnswerButtonType(Date.QuestionAndAnswers questionAndAnswers, GameObject button, int numberOfAnswer)
        {
            // Assign the correct and incorrect type of answer according to the dictionary. The dictionary value true is the correct answer
            questionAndAnswers.answers.TryGetValue(tempListOfAnswers[numberOfAnswer], out bool correctAnswer);

            if (correctAnswer)
            {
                button.GetComponent<AnswerButtonHandler>().isCorrectAnswer = true;
                correctAnswerButton = button;
            }
            else
                button.GetComponent<AnswerButtonHandler>().isCorrectAnswer = false;
        }

        void SetAnswerButtonText(TextMeshProUGUI buttonText, int numberOfAnswer)
        {
            stringBuilder.Clear();
            // Collect a text string from the designation and the answer
            stringBuilder.Append(designationsForAnswers[numberOfdesignations]);
            stringBuilder.Append(tempListOfAnswers[numberOfAnswer]);
            buttonText.text = stringBuilder.ToString();

            numberOfdesignations++;

            // Remove the assigned answer from the list so that the answers are unique
            tempListOfAnswers.Remove(tempListOfAnswers[numberOfAnswer]);
        }

        public void SetIndicationOfCorrectAnswerButtons()
        {
            correctAnswerButton.GetComponent<Image>().color = uIDate.correctColor;
        }

        void ActivateAnswerButtons()
        {
            fourthButton.interactable = true;
            thirdButton.interactable = true;
            secondButton.interactable = true;
            firstButton.interactable = true;
        }

        public void DeactivateAnswerButtons()
        {
            fourthButton.interactable = false;
            thirdButton.interactable = false;
            secondButton.interactable = false;
            firstButton.interactable = false;
        }
    }
}