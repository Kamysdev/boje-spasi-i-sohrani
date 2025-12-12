using NUnit.Framework;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    Cweapon currentWeapon;
    Ammunition ammunition;
    bool isFiring = false;

    // private void Update()
    // {
    //     if (currentWeapon != null && isFiring && currentWeapon.canFire)
    //     {
    //         if (currentWeapon.weaponEffect != null)
    //         {
    //             if (!currentWeapon.weaponEffect.isPlaying)
    //             {
    //                 currentWeapon.weaponEffect.Play();
    //             }
    //         }
    //     }
    // }

    void Start()
    {
        ammunition = GetComponent<Ammunition>();
        if (ammunition == null)
        {
            Debug.LogError("Ammunition component not found on " + gameObject.name);
        }
    }

    private void Update()
    {
        if (currentWeapon != null)
        {
            if (isFiring)
            {
                if (ammunition.checkAmmo(currentWeapon.getWeaponType()))
                {
                    if (currentWeapon.canFire)
                    {
                        currentWeapon.fire(ammunition);
                        
                        if (currentWeapon.weaponEffect != null)
                        {
                            if (currentWeapon.weaponEffect.isPlaying == false)
                            {
                                currentWeapon.weaponEffect.Play();
                            }
                        }
                    }
                }
                else
                {
                    if (currentWeapon != null)
                    {
                        if (currentWeapon.weaponEffect != null)
                        {
                            currentWeapon.weaponEffect.Stop();
                        }
                    }
                }
            }
        }
    }

    public void setWeapon(Cweapon weapon)
    {
        fireEnd();
        currentWeapon = weapon;
    }

    public void fireStart()
    {
        if (currentWeapon != null && currentWeapon.canFire)
        {
            isFiring = true;
            if (currentWeapon.weaponEffect != null)
            {
                //Instantiate(currentWeapon.weaponEffect, currentWeapon.firePoint.position, currentWeapon.firePoint.rotation).Play();

                //currentWeapon.weaponEffect.Play();
            }
        }
    }

    public void fireEnd()
    {
        isFiring = false;
        if (currentWeapon != null && currentWeapon.weaponEffect != null)
        {
            currentWeapon.weaponEffect.Stop();
        }
    }
}
