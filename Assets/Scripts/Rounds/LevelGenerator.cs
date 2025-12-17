using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEditor.Analytics;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> TileList;

    [SerializeField] private int Height = 2;
    [SerializeField] private int Width = 2;

    private Vector3 pos;
    private NavMeshSurface navmeshsurface;

    void Start()
    {
        navmeshsurface = GetComponent<NavMeshSurface>();

        pos = new Vector3(30, 0.15f, 30);
        Instantiate(TileList[Random.Range(0, 3)], pos, Quaternion.identity);
        pos = new Vector3(30, 0.15f, 50);
        Instantiate(TileList[Random.Range(0, 3)], pos, Quaternion.identity);
        pos = new Vector3(50, 0.15f, 30);
        Instantiate(TileList[Random.Range(0, 3)], pos, Quaternion.identity);
        pos = new Vector3(50, 0.15f, 50);
        Instantiate(TileList[Random.Range(0, 3)], pos, Quaternion.identity);

        Debug.Log("D:");

        navmeshsurface.BuildNavMesh();
    }
}
