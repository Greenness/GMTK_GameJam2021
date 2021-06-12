using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveLeftRight : MonoBehaviour
{
    public Rigidbody2D body2D;
    public Transform playerTransform;
    public float speed = .005f;
    float timeCounter = 0;
    void Update () {
            timeCounter += Time.deltaTime;
            float x = speed * Mathf.Cos (timeCounter);
            playerTransform.position += new Vector3(x,0);
    }


}
