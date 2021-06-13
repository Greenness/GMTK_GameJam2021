using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Vector2 movement;
    public SpriteRenderer sprite;
    public float rotateSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed);
    }

    void FixedUpdate() {
        transform.position = transform.position + (Vector3)movement * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject collidedObj = collision.gameObject;

        if (collidedObj.tag == "Obstacles") {
            gameObject.SetActive(false);
        } else if (collidedObj.tag == "Enemy") {
            gameObject.SetActive(false);
            collidedObj.SetActive(false);
        }
    }
}
