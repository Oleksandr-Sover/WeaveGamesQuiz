using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StartGameButtonSetter : MonoBehaviour
    {
        [SerializeField] Date.UIDate uIDate;

        void Awake()
        {
            gameObject.GetComponent<Image>().color = uIDate.accentColor;
        }
    }
}