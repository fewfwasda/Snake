using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBG : MonoBehaviour
{
    [SerializeField] private GameObject prefabBg;
    private Vector2 position;
    [SerializeField] private float space;

    private void Start()
    {
        position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SnakeHead"))
        {
            position.y += space;
            Instantiate(prefabBg, position, Quaternion.identity);
            Destroy(prefabBg, 8);
        }
    }
}