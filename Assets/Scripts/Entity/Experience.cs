using UnityEngine;
using UnityEngine.Events;

public class Experience : MonoBehaviour
{
    [SerializeField] private float ExperienceCount;
    [SerializeField] private int Level = 0;

    private float levelScaler = 10;

    public UnityEvent OnVFXPlay; 
    public UnityEvent<float, int, float> OnExperienceChange;

    void Start()
    {
        ExperienceCount = 5;
        expAdd(12);
    }

    public void expAdd(float amount)
    {
        ExperienceCount += amount;
        if (GetCurrentLevel())
        {
            // Для возможного проигрывания эффектов
            // OnVFXPlay?.Invoke(); 
        }
        OnExperienceChange?.Invoke(ExperienceCount, Level, levelScaler); // Обновление опыта и уровня в UI
    }

    public void expDecrease(float amount)
    {
        ExperienceCount -= amount;
        if (ExperienceCount < 0) 
        {
            ExperienceCount = 0;
            Level--;
        }
    }

    public bool GetCurrentLevel()
    {
        while (ExperienceCount > levelScaler) 
        {   
            ExperienceCount -= levelScaler;
            levelScaler = Level * 1.1f * levelScaler;
            Level++;
            return true;
        }

        return false;;
    }
}
