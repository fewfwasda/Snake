using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerBlock : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private float spacing;
    void Start()
    {
        Vector2 position = transform.position;
        for (int i = 0; i < 6; i++)
        {
            Instantiate(block, position,Quaternion.identity);
            position.x += spacing;
        }
    }


    void Update()
    {
    }
}