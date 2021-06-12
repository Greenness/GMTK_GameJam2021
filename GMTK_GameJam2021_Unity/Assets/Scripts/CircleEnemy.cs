using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemy : MonoBehaviour
{
    public Rigidbody2D body2D;
    public Transform playerTransform;
    public float speed = 5;
    float timeCounter = 0;
    void Update () {
            timeCounter += Time.deltaTime;
            float x = speed * Mathf.Cos (timeCounter);
            float y = speed * Mathf.Sin (timeCounter);
            playerTransform.position = new Vector2 (x,y);
    }
    
}
