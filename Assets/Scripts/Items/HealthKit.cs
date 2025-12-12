using UnityEngine;

public class HealthKit : MonoBehaviour, IItem
{
    [Range(1, 100)]
    [SerializeField] int amount = 50;

    public void onPickUp(GameObject player)
    {
        if (player.GetComponent<Health>().changeHealth(amount))
        {
            Destroy(gameObject);
        }
    }

    public void OggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPickUp(other.gameObject);
        }
    }

    public void setPosition(Vector3 position)
    {
        transform.position = position;
    }
}
