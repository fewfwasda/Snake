using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    private int value;
    private bool isBlock = false;
    private SnakeTail snakeM;
    private float wait = 0;
    [SerializeField] private TextMeshPro valueBlock;
    private SpriteRenderer newColor;

    private void Start()
    {
        newColor = GetComponent<SpriteRenderer>();

        ManagerBlock();
        snakeM = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<SnakeTail>();
    }


    private void Update()
    {
        wait += Time.deltaTime;
        if (wait >= 0.3f && isBlock)
        {
            snakeM.RemoveCircle();
            value--;
            wait = 0;
        }
        valueBlock.SetText(value.ToString());
        if (value <= 0) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SnakeHead"))
        {
            isBlock = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SnakeHead"))
        {
            isBlock = false;
        }
    }

    private void ManagerBlock()
    {
        value = Random.Range(1, 10);
        if (value > 5)
        {
            newColor.color = new Color(71, 0, 0, 255);
        }
        else
        {
            newColor.color = new Color(0, 71, 0, 255);
        }
    }
}