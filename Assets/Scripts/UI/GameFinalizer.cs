using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameFinalizer : MonoBehaviour
    {
        public void GoToHomeScreen()
        {
            SceneManager.LoadScene(0);
        }
    }
}