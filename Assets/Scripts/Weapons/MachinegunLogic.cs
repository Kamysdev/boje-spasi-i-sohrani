using UnityEngine;

public class MachinegunLogic : MonoBehaviour
{
    [SerializeField] LayerMask enemy;
    [Range(1, 12)]
    public int piercingPower = 3;

    public void shot(Transform fierPoint, float damage)
    {
        RaycastHit[] hits;

        Ray ray = new Ray(fierPoint.position, fierPoint.forward);
        hits = Physics.RaycastAll(ray, 100f, enemy);

        System.Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));

        if (hits.Length > 0)
        {
            for (int i = 0; i < Mathf.Min(piercingPower, hits.Length); i++)
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
}
