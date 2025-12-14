using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{

    public void nextLevel(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void exit ()
    {
        Debug.Log("на выход");
        Application.Quit();
    }
}
