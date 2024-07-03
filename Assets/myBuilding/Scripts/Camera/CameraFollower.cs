using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform snake;
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, snake.transform.position.y, transform.position.z);
    }
}