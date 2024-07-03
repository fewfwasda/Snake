using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnakeTail : MonoBehaviour
{
    [SerializeField] private Transform SnakeHead;
    [SerializeField] private float CircleDiameter;
    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector2> positions = new List<Vector2>();
    [SerializeField] private GameObject particle;
    private int Length = 1;
    private bool isBlock = false;
    public TextMeshPro PointsText;


    private void Awake()
    {
        positions.Add(SnakeHead.position);
    }

    private void Update()
    {
        float distance = ((Vector2)SnakeHead.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            Vector2 direction = ((Vector2)SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        if (Length == 0)
        {
            SceneManager.LoadScene(0);
            // Destroy(gameObject);
        }
        
        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector2.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }
    }

    public void AddCircle()
    {
        Length++;
        Transform circle = Instantiate(SnakeHead, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
        PointsText.SetText(Length.ToString());
    }

    public void RemoveCircle()
    {
        Length--;
        Destroy(snakeCircles[0].gameObject);
        snakeCircles.RemoveAt(0);
        positions.RemoveAt(0);
        PointsText.SetText(Length.ToString());
        Instantiate(particle, transform.position, Quaternion.identity);
    }
}