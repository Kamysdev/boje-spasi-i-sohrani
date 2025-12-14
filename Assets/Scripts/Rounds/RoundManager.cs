using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private UITime uiTime;
    [SerializeField] private UnityEvent waveSpawner;
    private int currentWave = 0;


    void Start()
    {
        // Example of starting the round timer
        currentWave = 1;
        StartRound();
    }

    public void StartRound()
    {
        uiTime.StartTimer();

        StartCoroutine(WaveSetup());
    }

    public void EndRound()
    {
        uiTime.StopTimer();
    }

    private IEnumerator WaveSetup()
    {
        while(true)
        {
            for (int i = 0; i < currentWave; i++)
            {
                waveSpawner.Invoke();
            }
            currentWave++;
            yield return new WaitForSeconds(5f);
        }
    }
}
