using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bl_Joystick joystick;
    private Rigidbody2D rb;
    [SerializeField]private int turnSeed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(joystick.Horizontal * turnSeed, speed);
    }
}