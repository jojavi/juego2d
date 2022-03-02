using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBk : MonoBehaviour
{
    // Start is called before the first frame update
    [Header ("Ground Detection")]
    [SerializeField] Transform GroundDetection;
    [SerializeField] float gdDistance;
    [SerializeField] LayerMask gdLayer;

    [Header ("Pathfinding")]
    public Transform target;
    public  float activateDistance = 50f;
    public float pathUpdateSeconds = 0.5f;
    
    [Header ("Physics")]
    public float speed = 200f;
    public  float netWaypointDistance = 3f;
    public float jumpNodeHeightRequeriment = 0.5f;

    public float jumpModifier = 0.3f;
    public float jumpCheckOffset = 0.1f;
    
    [Header ("Custom Behavior")]
    public bool followEnabled= true;
    public bool jumpEnabled = true;
    public bool directionLookEnabled = true;

    private Path path;
    private int currentWaypoint = 0;
    bool isGrounded = false;
    Seeker seeker;
    Rigidbody2D rb;


    GroundMover groundMover;

    Vector2 moveDirection;


    void Start()
    {
      //  groundMover =  GetComponent<GroundMover>();
      //  moveDirection = new Vector2(1f, 0f);
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f,pathUpdateSeconds);

    }

    // Update is called once per frame
    void Update()
    {
       // groundMover.FlipTransform(moveDirection.x);
       // CheckGroundDetection();

    }

    void FixedUpdate(){

        if(TargetInDistance() && followEnabled){
            
            PathFollow();
        }

        //groundMover.move(moveDirection.x);
    }

    private void UpdatePath()
    {
        if (followEnabled && TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnpathComplete);
        }
    }

    private void PathFollow()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        isGrounded = Physics2D.Raycast(transform.position, -Vector2.up, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);
        
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint]-rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        //JUMP
        if (jumpEnabled && isGrounded)
        {
            if(direction.y > jumpNodeHeightRequeriment)
            {
                rb.AddForce(Vector2.up * speed * jumpModifier);

            }
        }

        //Movement
        rb.AddForce(force);
        
        //Next Waypoint
        float distance  = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < netWaypointDistance)
        {
            currentWaypoint++;
        }

        //Direction Graphics Handling
        if (directionLookEnabled)
        {
            if(rb.velocity.x > 0.05f)
            {
                transform.localScale = new Vector2(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y);
            }
            else if (rb.velocity.x < -0.05f)
            {
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            }
        }
        
    }

    private bool TargetInDistance()
    {
        return  Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }

    private void OnpathComplete(Path p)
    {
        if (!p.error){

            path = p;
            currentWaypoint = 0;
        }
    }

    void CheckGroundDetection()
    {
        RaycastHit2D hit = Physics2D.Raycast(GroundDetection.position,  Vector2.down, gdDistance, gdLayer);
        if (hit.collider == null)
        {
            moveDirection.x *=-1f;
        }
    }


}
