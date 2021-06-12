using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMove : MonoBehaviour
{
    
    /*private float timer = 0.0f;
    public  float maxMovementTime = 5.0f;

    public float verticalForce = 10f;
    

    void FixedUpdate() {
        timer += Time.deltaTime;

        // Check if we have reached 5 seconds.
        if (timer >= maxMovementTime)
        {
            timer = 0;
            verticalForce *= -1;
        }
        body2D.AddForce(new Vector2(0, verticalForce));

    }*/

    
    public Rigidbody2D body2D;
    public Transform playerTransform;
    public float speed = 5;
    float timeCounter = 0;
    void Update () {
            timeCounter += Time.deltaTime;
            float y = speed * Mathf.Sin (timeCounter);
            playerTransform.position += new Vector3(0, y);
    }
    
}
