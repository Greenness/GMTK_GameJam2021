using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Rigidbody2D Rbody;
    public Transform HealthPos;

    void OnCollisionEnter2D(Collision2D collision) {
         GameObject collidedObj = collision.gameObject;

         if (collidedObj.tag == "Player") {
            gameObject.SetActive(false);
         }
    }
}
