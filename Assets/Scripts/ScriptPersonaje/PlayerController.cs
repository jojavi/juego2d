using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{

   // [SerializeField] private GroundMover groundMover;
   private GroundMover groundMover;
    private Vector2 moveInput;

    private ProjectileSpawner projectileSpawner;

    // Start is called before the first frame update
    //private GroundMover groundMover2();
    void Start()
    {
        groundMover = GetComponent<GroundMover>();
        projectileSpawner = GetComponent<ProjectileSpawner>();
    }

    // Update is called once per frame
    void Update()
    {  
        
        groundMover.move(moveInput.x);
        if(Mathf.Abs(moveInput.x)> Mathf.Epsilon)
        {
            groundMover.FlipTransform(moveInput.x);
        }
        
    }

    private void FixedUpdate() {
        
     // groundMover.move(moveInput.x);
       
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)

    {

        groundMover.jump(context.action.triggered);

    }

      public void OnFire(InputAction.CallbackContext context)

    {

        if (!context.action.triggered) { return; }

        projectileSpawner.Fire();

    }


}
