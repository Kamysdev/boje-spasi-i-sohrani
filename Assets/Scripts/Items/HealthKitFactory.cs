using UnityEngine;

public class HealthKitFactory : ItemFactory
{
    [SerializeField] GameObject healthKitPrefab;

    public override IItem getItem()
    {
        GameObject healthKitInstance = Instantiate(healthKitPrefab);
        return healthKitInstance.GetComponent<HealthKit>();
    }
}
