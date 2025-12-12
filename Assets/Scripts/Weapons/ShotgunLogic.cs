using System.Collections.Generic;
using UnityEngine;

public class ShotgunLogic : MonoBehaviour
{
    [SerializeField] LayerMask enemy;
    [SerializeField] int backshots = 8;
    [SerializeField] float spread = 40.0f;

    public List<Vector3> shot(Transform firePoint, float damage)
    {
        List<Vector3> directions = new List<Vector3>();

        for (int i = 0; i < backshots; i++)
        {
            float angle = Random.Range(-spread, spread);
            var quaternion = Quaternion.Euler(0, angle, 0);
            var newDirection = quaternion * firePoint.forward;

            directions.Add(newDirection);
        }

        foreach (var direction in directions)
        {
            RaycastHit hit;

            if (Physics.Raycast(firePoint.position, direction, out hit, 1000f, enemy))
            {
                Debug.Log($"Hit: {hit.collider.name} with damage: {damage}");
            }
        }

        return directions;
    }
}
