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
            RaycastHit[] hits;

            Ray ray = new Ray(firePoint.position, firePoint.forward);
            hits = Physics.RaycastAll(ray, 100f, enemy);

            System.Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));

            if (hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    Health enemyHP = hits[i].transform.GetComponent<Health>();
                    Debug.Log($"Hit enemy: {hits[i].transform.name} with damage: {damage}");
                    if (enemyHP != null)
                    {
                        enemyHP.hpDecrease(damage);
                    }
                }
            }
        }

        return directions;
    }
}
