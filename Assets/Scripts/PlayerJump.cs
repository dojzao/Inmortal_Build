using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerJump : MonoBehaviour
{
    //fuerza, aplicarla. 1x

    [Header("Jump Details")]
    [SerializeField] public float jumpForce;
    [SerializeField] public float jumpTime;
    [SerializeField] private float jumpTimeCounter;
    [SerializeField] private bool stoppedJumping;
    
    [Header("Ground Details")]
    [SerializeField] private Transform groundchequeo;
    [SerializeField] private float radOCircle;
    [SerializeField] private LayerMask whatIsGround; 
    // Start is called before the first frame update
    [SerializeField] public bool grounded;
    
    [Header("Components")]
    private Rigidbody2D rb;
    private Animator myAnimator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;    
    }


    
    // Update is called once per frame
    private void Update()
    {
        if (grounded || rb.velocity.y == 0)
        {
           jumpTimeCounter = jumpTime;
           myAnimator.ResetTrigger("jump");
           myAnimator.SetBool("falling",false);
        
         
        }
        //lo que estar en el piso
        grounded= Physics2D.OverlapCircle(groundchequeo.position,radOCircle,whatIsGround);
        //usar space and w to jump
        if(Input.GetButton("Jump") && (grounded  || rb.velocity.y == 0) )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            stoppedJumping = false;
            //animator hace jump
            myAnimator.SetTrigger("jump");
        
        }
        //to keep jumping holding it
        if(Input.GetButton("Jump") && !stoppedJumping && jumpTimeCounter>0)
        {
            
            //jump farther
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
            myAnimator.SetTrigger("jump");
            
        }
        //if we release the jump button
        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
            myAnimator.SetBool("falling",true);
            myAnimator.ResetTrigger("jump");
        
        
        }
        if(rb.velocity.y < 0)
        {
            myAnimator.SetBool("falling",true);
            myAnimator.ResetTrigger("jump");
                
        }
        
    }

    private void OnDrawGizmos(){
        Gizmos.DrawSphere(groundchequeo.position,radOCircle);
    }

    private void FixedUpdate()
    {
        HandleLayers();
    }
    private void HandleLayers()
    
    {

        if(!grounded){

            myAnimator.SetLayerWeight(1,1);
        }else{

            myAnimator.SetLayerWeight(1,0);
        }
        
    }
}
