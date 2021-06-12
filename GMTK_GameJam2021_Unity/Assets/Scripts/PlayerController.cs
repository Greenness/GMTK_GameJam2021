using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask platformMask;

    public Rigidbody2D body2D;
    public BoxCollider2D collider2D;
    public Transform playerTransform;
    public Camera cam;
    public Animator animator;
    public GameObject gameControllerInstance;
    public SpriteRenderer sprite;

    public Vector3 mousePosition;
    public Vector3 playerPosition;

    public Vector3 aim;
    public float recoil;
    public float direction;
    public float speed;
    public float speedCap;

    public float health;
    public float massLoss;
    public float bulletSpeed = 15.0f;

    public bool isGrounded;
    public bool isDamaged;
    public bool isThrowing;
    public bool facingLeft;

    public AnimationClip[] walkClips;
    public AnimationClip[] idleClips;
    public AnimationClip[] risingClips;
    public AnimationClip[] fallingClips;
    public AnimationClip[] damagedClips;
    public AnimationClip[] throwClips;
    

    // Start is called before the first frame update
    void Start()
    {
        //get Camera component to get more accurate mouse position
        cam = Camera.main;

        //set defaults for main variables
        recoil = 20;
        direction = -1;
        speed = .05f;
        speedCap = 50;
        health = 10;
        massLoss = 1;
        facingLeft = false;
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
        //speed cap
        if (body2D.velocity.x < 50 && body2D.velocity.x > -50) {
            //Move right
            if (Input.GetKey("d"))
            {
                //playerTransform.Translate (Vector3.right * speed * Time.deltaTime);
                body2D.velocity += Vector2.right * speed;
            }

            //Move left
            if (Input.GetKey("a"))
            {
                //playerTransform.Translate (Vector3.left * speed * Time.deltaTime);
                body2D.velocity += Vector2.left * speed;
            }
        }

        

        //ATTACK
        //Mouse click control
        if (Input.GetButtonDown("Fire1")) {
            Vector3 trajectory = (recoil*direction) * aim;
            body2D.velocity = trajectory;
            health -= massLoss;
            recoil += massLoss*2;

            shootBullet();
        }

        //DEATH
        //Logic for when health runs out
        if (health < 0)
        {
            //gameObject.SetActive() = false;
            recover();
        }

        //ANIMATION
        isGrounded = GroundCheck();
        PlayerAnimation();
    }

    void shootBullet()
    {
        Vector2 bulletVelocity = bulletSpeed * aim;
        gameControllerInstance.GetComponent<GameControl>().shootNewBullet(transform.position, bulletVelocity);
    }

    void recover()
    {
        //Reset health and recoil
        recoil = 20;
        health = 10;
    }

    //Check if Player is on the ground
    bool GroundCheck()
    {
        RaycastHit2D hit;
        float extra = .5f;

        hit = Physics2D.Raycast(collider2D.bounds.center, Vector2.down, collider2D.bounds.extents.y + extra, platformMask);
        return hit.collider != null;
    }

    void PlayerAnimation()
    {
        animator.SetInteger("VelocityX", (int)body2D.velocity.x);
        animator.SetInteger("VelocityY", (int)body2D.velocity.y);
        animator.SetInteger("Health", (int)health);

        animator.SetBool("IsGrounded", isGrounded);
        animator.SetBool("IsDamaged", isDamaged);
        animator.SetBool("IsThrowing", isThrowing);

        //Flip sprite
        if (body2D.velocity.x > 0)
        {
            facingLeft = false;
        } else if (body2D.velocity.x < 0) {
            facingLeft = true;
        }
        sprite.flipX = facingLeft;
    }
}