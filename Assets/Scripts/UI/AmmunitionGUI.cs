using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmunitionGUI : MonoBehaviour
{
    public Ammunition ammunition;

    public List<WeaponGUI> weaponsList;
    [SerializeField]
    Dictionary<WeaponTypes, TMP_Text> weaponsDictionary;

    public void listToDictionary()
    {
        weaponsDictionary = new Dictionary<WeaponTypes, TMP_Text>();

        foreach (var weapon in weaponsList)
        {
            if (weaponsDictionary.ContainsKey(weapon.weaponType) == false)
            {
                weaponsDictionary.Add(weapon.weaponType, weapon.text);
            }
        }
    }

    private void Start() => listToDictionary();

    public void updateGUI()
    {
        foreach (KeyValuePair<WeaponTypes, int> kvp in ammunition.ammoDictionary)
        {
            Debug.Log("Updating GUI for weapon type: " + kvp.Key);
            if (weaponsDictionary.ContainsKey(kvp.Key))
            {
                weaponsDictionary[kvp.Key].text = kvp.Value.ToString();
                Debug.Log($"Updated {kvp.Key} ammo count to {kvp.Value}");
            }
        }
    }
}