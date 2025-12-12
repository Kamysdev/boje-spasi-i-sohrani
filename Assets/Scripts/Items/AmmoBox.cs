using UnityEngine;

public class AmmoBox : MonoBehaviour, IItem
{
    [SerializeField] WeaponTypes weaponType;
    [Range(1, 100)]
    [SerializeField] int amount = 30;

    public void onPickUp(GameObject player)
    {
        if (player.GetComponent<Ammunition>().addAmmo(weaponType, amount))
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
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