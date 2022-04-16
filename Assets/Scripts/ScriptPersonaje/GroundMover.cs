using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundMover : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float walkSpeed = 7f;

    [SerializeField] public float jumpHeight = 8f;

    [Range(0, 1)] [SerializeField] private float jumpVelModifier = 1f;

    //[SerializeField] private float jumpStartingVel = 24f;
    
    [SerializeField] private LayerMask jumpableLayers;
    [SerializeField] private LayerMask climbableLayers;

     [SerializeField] public float climbSpeed = 7f;

    private Rigidbody2D rb;

    private CapsuleCollider2D capCollider;

    private BoxCollider2D feetboxCollider;
    private Animator animator;
    
    private float gravityScale = 1f;
    private void Awake() {
        //GetComponent <Rigidbody2D> ();        
        rb = GetComponent<Rigidbody2D>();

        capCollider = GetComponent<CapsuleCollider2D>();

        animator = GetComponent<Animator>();
        feetboxCollider = GetComponent<BoxCollider2D>();
        gravityScale = rb.gravityScale;
    }

     /*
    public void move(float moveX){

        
       rb.velocity = new Vector2 ( moveX * walkSpeed, rb.velocity.y );
         
         //if (KeyValuePair && capCollider.IsTouchingLayers(jumpableLayers))
         
         if (moveX != 0)
         {
             rb.velocity =new Vector2(moveX * walkSpeed, playerRigidbody.velocity.y);
         }


        if (moveX != 0){
            animator.SetBool("isWalking", true);

        }
        else {
            animator.SetBool("isWalking", false);
        }

    }*/
    public void move(float moveX)

    {

        rb.velocity = new Vector2(moveX * walkSpeed, rb.velocity.y);

        if (moveX != 0)

        {

            animator.SetBool("isWalking", true);

        }

        else

        {

            animator.SetBool("isWalking", false);

        }



    }
   

    public void Climb(float moveY)
    {

        if (!capCollider.IsTouchingLayers(climbableLayers) || !feetboxCollider.IsTouchingLayers(climbableLayers))
        {

            rb.gravityScale = gravityScale;
            return;

        }
        rb.velocity = new Vector2(rb.velocity.x, moveY * climbSpeed);
        rb.gravityScale = 0f;

    }


       

    public void jump(bool value)

    {

      //  if (!capCollider.IsTouchingLayers(jumpableLayers)){return;}

    

        if (value){
            
            if (capCollider.IsTouchingLayers(jumpableLayers))
            {

           
           // rb.velocity = new Vector2(rb.velocity.x, jumpStartingVel);
           // rb.velocity = new Vector2(rb.velocity.x, Mathf.Sqrt(2*10*jumpHeight));
           rb.velocity = new Vector2(rb.velocity.x, Mathf.Sqrt(-2*gravityScale*Physics2D.gravity.y * jumpHeight));
             }
             else
             {
                 if(rb.velocity.y > Mathf.Epsilon)
                 {
                     rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y * jumpVelModifier);
                 }

             }


        }

    }


    public void FlipTransform (float moveX)
    {
        transform.localScale = new Vector2(Mathf.Sign(moveX),1f);
    }

}
