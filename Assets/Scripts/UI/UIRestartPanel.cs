using UnityEngine;
using UnityEngine.SceneManagement;

public class UIRestart : MonoBehaviour
{

    public GameObject panel;

    public void IsShowPanel()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Start()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        
    }
}
