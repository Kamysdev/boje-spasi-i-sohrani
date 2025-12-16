using TMPro;
using UnityEngine;

public class UITime : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;

    private float currentTime;
    private bool isRunning;

    void Update()
    {
        if (!isRunning) return;

        currentTime += Time.deltaTime;
        UpdateTimeText();
    }

    public void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        timeText.text = $"{minutes:00}:{seconds:00}";
    }

    public void StartTimer()
    {
        currentTime = 0f;
        isRunning = true;
        UpdateTimeText();
    }

    public void StopTimer() => isRunning = false;

    public void ResumeTimer() => isRunning = true;

    public float GetTime()
    {
        return currentTime;
    }
}
