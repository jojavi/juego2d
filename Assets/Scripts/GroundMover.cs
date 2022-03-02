using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundMover : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float walkSpeed = 7f;

    [SerializeField] public float jumpHeight = 8f;

    

    //[SerializeField] private float jumpStartingVel = 24f;
    
    [SerializeField] private LayerMask jumpableLayers;

    private Rigidbody2D rb;

    private CapsuleCollider2D capCollider;
    private Animator animator;
    

    private void Awake() {
        //GetComponent <Rigidbody2D> ();        
          rb = GetComponent<Rigidbody2D>();

        capCollider = GetComponent<CapsuleCollider2D>();

        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void move(float moveX){

        rb.velocity = new Vector2 ( moveX * walkSpeed, rb.velocity.y );
        
        if (moveX != 0){
            animator.SetBool("isWalking", true);

        }
        else {
            animator.SetBool("isWalking", false);
        }

        

    }

       

    public void jump(bool value)

    {

        if (!capCollider.IsTouchingLayers(jumpableLayers)){return;}



        if (value){

           // rb.velocity = new Vector2(rb.velocity.x, jumpStartingVel);
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Sqrt(2*10*jumpHeight));
           
    

        }

    }


    public void FlipTransform (float moveX)
    {
        transform.localScale = new Vector2(Mathf.Sign(moveX),1f);
    }

}
