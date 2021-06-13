using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemy : MonoBehaviour
{
    public Rigidbody2D body2D;
    public Transform playerTransform;
    public float radius = 2;
    public float speed = 5;
    float timeCounter = 0;
    public Vector2 start;
    
    void Start ()
    {
        start = playerTransform.position;
    }

    void Update () {
            timeCounter += Time.deltaTime;
            float x = radius + speed * Mathf.Cos (timeCounter);
            float y = radius + speed * Mathf.Sin (timeCounter);
            playerTransform.position = new Vector2 (start.x + x, start.y + y);
    }
    
}