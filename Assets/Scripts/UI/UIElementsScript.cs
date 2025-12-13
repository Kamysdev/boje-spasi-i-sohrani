using TMPro;
using UnityEngine;

public class UIElementsScript : MonoBehaviour
{
    [SerializeField] private TMP_Text hpText;

    private Health playerHealth;

    void Start()
    {
        // Леся должна мне 1 додстер
        playerHealth = GameObject.Find("Player").GetComponent<Health>();
        UpdateHP(playerHealth.currentHealth, playerHealth.maximumHealth);
    }

    public void UpdateHP(int currentHealth, int maximumHealth)
    {
        hpText.text = $"{currentHealth}/{maximumHealth}";
    }
}
