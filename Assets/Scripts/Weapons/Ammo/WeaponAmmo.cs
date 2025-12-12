using System;

public enum WeaponTypes { Machinegun, Shotgun, Flamer, Plasmegun };

[Serializable]
public class WeaponAmmo
{
    public WeaponTypes type;
    public int ammo;
}
