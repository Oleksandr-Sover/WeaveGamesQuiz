using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameBreaker : MonoBehaviour
    {
        [SerializeField] Date.UIDate uIDate;

        void Awake()
        {
            gameObject.GetComponent<Image>().color = uIDate.wrongColor;
        }

        public void QuitGame()
        {
#if UNITY_EDITOR

            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}