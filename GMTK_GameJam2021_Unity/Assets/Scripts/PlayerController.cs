using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D body2D;
    public Transform playerTransform;
    public Camera cam;

    public Vector3 mousePosition;
    public Vector3 playerPosition;

    public Vector3 aim;
    public float recoil;
    public float direction;
    public float speed;

    public float health;
    public float massLoss;

    // Start is called before the first frame update
    void Start()
    {
        //get Camera component to get more accurate mouse position
        cam = Camera.main;

        //set defaults for main variables
        recoil = 20;
        direction = -1;
        speed = 7;
        health = 11;
        massLoss = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //get or update current player position
        playerPosition = playerTransform.position;

        //update current mouse position
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        //calculate aim trajectory
        aim = Vector3.Normalize(mousePosition - playerPosition);

        //Player MOVEMENT
        //Move right
        if (Input.GetKey("d"))
        {
            playerTransform.Translate (Vector3.right * speed * Time.deltaTime);
            //body2D.velocity = new Vector2(speed, 0);
        }

        //Move left
        if (Input.GetKey("a"))
        {
            playerTransform.Translate(Vector3.left * speed * Time.deltaTime);
            //body2D.velocity = new Vector2 (-speed, 0);
        }

        //ATTACK
        //Mouse click control
        if (Input.GetButtonDown("Fire1")) {
            recoil += massLoss;
            Vector3 trajectory = (recoil*direction) * aim;
            body2D.velocity = trajectory;
            health -= 1;
            recoil += massLoss;
        }

        //DEATH
        //Logic for when health runs out
        if (health <= 0) {
            //gameObject.SetActive() = false;
        }
    }
}
