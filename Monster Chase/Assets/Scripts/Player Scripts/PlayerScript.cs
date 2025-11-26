using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    // CONSTANTS
    private const string WALK_ANIMATION = "Walk";
    private const string IS_GROUND_TAG = "Ground";

    private float moveX;
    [SerializeField]
    private float motionForce;
    [SerializeField]
    private float jumpForce;
    private bool isGrounded = true;




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
        this.jumpForce = 16f;
        
    }
    // Update is called once per frame
    void Update()
    {
        WalkPlayer();
        WalkAnimation();
        JumpPlayer();
        
        
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

}
