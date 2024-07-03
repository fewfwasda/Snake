using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerFood : MonoBehaviour
{
    [SerializeField] private GameObject prefabFood;

    // [SerializeField] private float minboundsX;
    // [SerializeField] private float maxboundsX;
    // [SerializeField] private float minboundsY;
    // [SerializeField] private float maxboundsY;
    private Vector2 position;

    void Start()
    {
        position = transform.position;
        SpawnFood();
    }

    private void SpawnFood()
    {
        
        Vector2 randomSpawnPosition = new Vector2(Random.Range(position.x - 6, position.x + 6),
            Random.Range(position.y - 2, position.y + 2));
        Instantiate(prefabFood, randomSpawnPosition, Quaternion.identity);
    }
}