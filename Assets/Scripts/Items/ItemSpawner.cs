using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] List<ItemPropability> itemFactoriesWithProbs = new List<ItemPropability>();
    List<ItemFactory> itemFactories = new List<ItemFactory>();
    ItemFactory itemFactory;

    public void Start()
    {
        float propabilitySum = 0f;

        foreach(var item in itemFactoriesWithProbs)
        {
            propabilitySum += item.propability;
        }

        foreach(var item in itemFactoriesWithProbs)
        {
            item.propability = Mathf.Floor(item.propability / propabilitySum * 100f);
        }

        foreach (var item in itemFactoriesWithProbs)
        {
            for (int i = 0; i < item.propability; i++)
            {
                itemFactories.Add(item.itemFactory);
            }
        }
    }

    public void spawnRandomItems(Vector3 pos)
    {
        itemFactory = itemFactories[Random.Range(0, itemFactories.Count)];

        IItem item = itemFactory.getItem();

        // Vector3 direction = new Vector3(Random.insideUnitCircle.x, 0, Random.insideUnitCircle.y);
        // direction = direction.normalized * Random.Range(3, 6);
        // Vector3 position = transform.position + direction;

        item.setPosition(pos);
    }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Tab))
    //     {
    //         spawnRandomItems();
    //     }
    // }
}
