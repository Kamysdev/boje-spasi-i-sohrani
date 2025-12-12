using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<EnemyFactory> enemyFactories = new List<EnemyFactory>();
    [SerializeField] Transform player;
    EnemyFactory enemyFactory;

    void Start()
    {
        StartCoroutine(WaveSpawner());
    }

    public void spawnEnemy()
    {
        enemyFactory = enemyFactories[Random.Range(0, enemyFactories.Count)];

        IEnemy enemy = enemyFactory.getEnemy();
        enemy.Player = player;

        Vector3 direction = new Vector3(Random.insideUnitCircle.x, 0, Random.insideUnitCircle.y);
        direction = direction.normalized * Random.Range(3, 6);
        Vector3 position = transform.position + direction;

        enemy.positionAndRotation(position, Quaternion.identity);
        Health enemyHP = enemy.EnemyHP;
        enemyHP.spawnOnDeath.AddListener(pos => GetComponent<ItemSpawner>().spawnRandomItems(pos));
    }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //         spawnEnemy();
    // }

    private IEnumerator WaveSpawner()
    {
        while (true)
        {
            spawnEnemy();

            yield return new WaitForSeconds(15f);
        }
    }
}
