using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(TracerSystem))]
[RequireComponent(typeof(MachinegunLogic))]
public class CMachineGun : Cweapon
{
    TracerSystem tracerSystem;
    MachinegunLogic machinegunLogic;

    private void Start()
    {
        tracerSystem = GetComponent<TracerSystem>();
        machinegunLogic = GetComponent<MachinegunLogic>();
    }

    public override void fire(Ammunition ammunition)
    {
        base.fire(ammunition);

        tracerSystem.createTracer(firePoint.position, firePoint.forward);
        machinegunLogic.shot(firePoint, damage);
    }

    public override WeaponTypes getWeaponType()
    {
        return WeaponTypes.Machinegun;
    }
}
