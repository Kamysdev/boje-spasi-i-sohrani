using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TracerSystem))]
[RequireComponent(typeof(ShotgunLogic))]
public class CLaserShotgun : Cweapon
{
    TracerSystem tracerSystem;
    ShotgunLogic shotgunLogic;

    private void Start()
    {
        tracerSystem = GetComponent<TracerSystem>();
        shotgunLogic = GetComponent<ShotgunLogic>();
    }

    public override void fire(Ammunition ammunition)
    {
        base.fire(ammunition);

        List<Vector3> directions = shotgunLogic.shot(firePoint, damage);

        foreach (var direction in directions)
        {
            tracerSystem.createTracer(firePoint.position, direction);
        }
    }

    public override WeaponTypes getWeaponType()
    {
        return WeaponTypes.Shotgun;
    }
}
