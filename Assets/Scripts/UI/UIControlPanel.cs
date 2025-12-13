using UnityEngine;

public class UIControlPanel : MonoBehaviour
{
    public GameObject panel;
    public bool IsShow;

    void Start()
    {
        IsShow = false;
        panel.SetActive(IsShow);
    }

    public void ShowAndHidePanel()
    {
        if (IsShow == false)
        {
            IsShow = true;
            panel.SetActive(IsShow);     
                   
        }
        else
        {
            IsShow = false;
            panel.SetActive(IsShow); 
        }

    }
}
