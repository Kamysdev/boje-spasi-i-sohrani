using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class Ammunition : MonoBehaviour
{
    public List<WeaponAmmo> ammoList = new List<WeaponAmmo>(); 
    public Dictionary<WeaponTypes, int> ammoDictionary;

    public UnityEvent onAmmoChange;

    public void listToDictionary()
    {
        ammoDictionary = new Dictionary<WeaponTypes, int>();

        foreach (var ammo in ammoList)
            if (ammoDictionary.ContainsKey(ammo.type) == false)
                ammoDictionary.Add(ammo.type, ammo.ammo);
    }

    private void Start()
    {
        listToDictionary();
        onAmmoChange?.Invoke();
    }

    public bool checkAmmo(WeaponTypes type)
    {
        if (ammoDictionary.ContainsKey(type) == false)
        {
            //Debug.LogWarning($"Ammo type {type} not found in dictionary.");
            return false;
        }
        if (ammoDictionary[type] < 1)
        {
            //Debug.LogWarning($"No ammo left for weapon type {type}.");
            return false;
        }

        return true;
    }

    public bool getAmmo(WeaponTypes type)
    {
        if (ammoDictionary.ContainsKey(type) == false)
        {
            //Debug.LogWarning($"Ammo type {type} not found in dictionary.");
            return false;
        }
        if (ammoDictionary[type] < 1)
        {
            //Debug.LogWarning($"No ammo left for weapon type {type}.");
            return false;
        }

        ammoDictionary[type]--;
        onAmmoChange?.Invoke();

        return true;
    }

    public bool addAmmo(WeaponTypes type, int amount)
    {
        if (ammoDictionary.ContainsKey(type) == false)
        {
            //Debug.LogWarning($"Ammo type {type} not found in dictionary.");
            return false;
        }

        ammoDictionary[type] += amount;
        onAmmoChange?.Invoke();

        return true;
    }
}
