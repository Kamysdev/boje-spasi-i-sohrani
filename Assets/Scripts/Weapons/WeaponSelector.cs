using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public Transform weaponHolder;
    private int selectedWeaponIndex = 1;

    private void Start()
    {
        SetWeaponFalse();
    }

    public void SelectNextWeapon()
    {
        SetWeaponFalse();
        selectedWeaponIndex++;

        if (selectedWeaponIndex > weaponHolder.childCount - 1) selectedWeaponIndex = 0;

        SetWeaponActive();
    }

    public Cweapon selectNextWeapon()
    {
        foreach (Transform child in weaponHolder)
        {
            child.gameObject.SetActive(false);
        }

        selectedWeaponIndex++;

        if (selectedWeaponIndex > weaponHolder.childCount - 1) selectedWeaponIndex = 0;

        weaponHolder.GetChild(selectedWeaponIndex).gameObject.SetActive(true);
        return weaponHolder.GetChild(selectedWeaponIndex).gameObject.GetComponent<Cweapon>();
    }

    public Cweapon getSelectedWeapon()
    {
        var weapon = weaponHolder.GetChild(selectedWeaponIndex).gameObject.GetComponent<Cweapon>();
        return weapon;
    }

    public void SelectPrevWeapon()
    {
        SetWeaponFalse();
        selectedWeaponIndex--;

        if (selectedWeaponIndex < 0) selectedWeaponIndex = weaponHolder.childCount - 1;

        SetWeaponActive();
    }

    public Cweapon selectPrevWeapon()
    {
        foreach (Transform child in weaponHolder)
        {
            child.gameObject.SetActive(false);
        }

        selectedWeaponIndex--;

        if (selectedWeaponIndex < 0) selectedWeaponIndex = weaponHolder.childCount - 1;

        weaponHolder.GetChild(selectedWeaponIndex).gameObject.SetActive(true);
        return weaponHolder.GetChild(selectedWeaponIndex).gameObject.GetComponent<Cweapon>();
    }

    public void SelectWEaponByIndex(int index)
    {
        SetWeaponFalse();

        if (index > -1 && index <= weaponHolder.childCount)
        {
            selectedWeaponIndex = index;
            SetWeaponActive();
        }
    }

    public Cweapon selectWeaponByIndex(int index)
    {
        foreach (Transform child in weaponHolder)
        {
            child.gameObject.SetActive(false);
        }

        if (index > -1 && index < weaponHolder.childCount)
        {
            selectedWeaponIndex = index;
            weaponHolder.GetChild(selectedWeaponIndex).gameObject.SetActive(true);
            return weaponHolder.GetChild(selectedWeaponIndex).gameObject.GetComponent<Cweapon>();
        }

        return null;
    }

    public void SetWeaponFalse()
    {
        foreach (Transform child in weaponHolder)
        {
            child.gameObject.SetActive(false);
        }
    }
    
    private void SetWeaponActive() => weaponHolder.GetChild(selectedWeaponIndex).gameObject.SetActive(true);
}
