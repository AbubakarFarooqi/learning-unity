using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    // CONSTANTS
    private const string WALK_ANIMATION = "Walk";
    private const string JUMP_ANIMATION = "Jump";
    private const string IS_GROUND_TAG = "Ground";
    private bool isGrounded = true;
    private bool isBulletOnScreen = false;
    private float moveX;

    [SerializeField]
    private float motionForce;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private GameObject bulletReference;
    [SerializeField]
    private Rigidbody2D myBody;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform transform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.myBody.gravityScale = 5;
        this.motionForce = 8.5f;
        
    }
    void Awake()
    {
        BulletScript.OnEnemyHit += HandleBulletHitEnemy;
        BulletScript.onDestoryBullet += HandleBulletDestroy;
    }
    // Update is called once per frame
    void Update()
    {
        WalkPlayer();
        WalkAnimation();
        JumpPlayer();
        this.animator.SetBool(JUMP_ANIMATION,!isGrounded);
        ShootBullet();

        
    }

    void WalkPlayer()
    {   
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            this.moveX = -1f;
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            this.moveX = 1f;
        else
        {
            this.moveX = 0;
        }
        this.transform.position += new Vector3(moveX,0,0) *  this.motionForce * Time.deltaTime;
    }
    void WalkAnimation()
    {
        if (moveX > 0)
        {
            this.animator.SetBool(WALK_ANIMATION,true);
            this.spriteRenderer.flipX = false;
        }
        else if (moveX < 0)
        {
            this.animator.SetBool(WALK_ANIMATION,true);
            this.spriteRenderer.flipX = true;
            
        }
        else
        {
            this.animator.SetBool(WALK_ANIMATION,false);
            
        }
    }

    void JumpPlayer()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && this.isGrounded)
        {
            this.isGrounded = false;
            this.myBody.AddForce(new Vector2(0f,this.jumpForce),ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(IS_GROUND_TAG))
            this.isGrounded = true;
    }

    void ShootBullet()
    {
        
        if (!isBulletOnScreen && Mouse.current.leftButton.IsPressed())
        {
            Debug.LogWarning("MOuse clicked");
            var bullet = Instantiate(bulletReference);
            isBulletOnScreen = true;

            if (!spriteRenderer.flipX)
            {
                bullet.transform.position = new Vector2(this.GetComponent<CapsuleCollider2D>().bounds.center.x+this.GetComponent<CapsuleCollider2D>().bounds.extents.x+0.5f,this.GetComponent<CapsuleCollider2D>().bounds.center.y );
                bullet.GetComponent<SpriteRenderer>().flipX = true;
                bullet.GetComponent<BulletScript>().speed = 10f;
            }
            else
            {
                bullet.transform.position = new Vector2(this.GetComponent<CapsuleCollider2D>().bounds.center.x-this.GetComponent<CapsuleCollider2D>().bounds.extents.x-0.5f,this.GetComponent<CapsuleCollider2D>().bounds.center.y );
                bullet.GetComponent<BulletScript>().speed = -10f;
                
            }
           
            
            // Debug.Log("x: "+this.transform.position.x.ToString());
            // Debug.Log("width: "+this.GetComponent<CapsuleCollider2D>().bounds.size.x.ToString());
            // Debug.Log("y: "+this.transform.position.y.ToString());
        }
    }

    void HandleBulletHitEnemy(int score)
    {
        isBulletOnScreen = false;
    }
    void HandleBulletDestroy()
    {
        isBulletOnScreen = false;
    }
}
