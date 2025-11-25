using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private const string WALK_ANIMATION = "Walk";
    private float moveX;
    [SerializeField]
    private float moitionForce;
    [SerializeField]
    private Rigidbody2D rigidbody2D;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform transform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        WalkPlayer();
        WalkAnimation();
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
        this.transform.position += new Vector3(moveX,0,0) *  this.moitionForce * Time.deltaTime;
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
}
