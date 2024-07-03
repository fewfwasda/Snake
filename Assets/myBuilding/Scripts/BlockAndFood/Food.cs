using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
    private int value;
    [SerializeField] private TextMeshPro valueFood;

    private void Start()
    {
        value = Random.Range(1, 10);
        
    }

    private void Update()
    {
        valueFood.SetText(value.ToString());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            for (int i = 0; i < value; i++)
            {
                SnakeTail snakeTail = other.GetComponent<SnakeTail>();
                if (snakeTail != null)
                {
                    snakeTail.AddCircle();
                }
    
                Destroy(gameObject);
            }
        }
    }
}