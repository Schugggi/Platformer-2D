using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJumps;
    public int extraJumpValue;
    private Inventory inventory;
    private void Awake(){
        inventory = new Inventory();
    }
    private void Start() {
        Flip();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {

        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        

        if(facingRight == false && moveInput > 0){
            Flip();
        }
        else if(facingRight == true && moveInput < 0){
            Flip();
        }
    }
    void Update() {
        if(isGrounded == true){
            extraJumps = extraJumpValue;
            
        }
        if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0){
            rb.velocity = Vector2.up * jumpForce;
            
            extraJumps--;
        }else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true){
            rb.velocity =Vector2.up * jumpForce;
            
        }else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && !isGrounded){
           
        }
    }
    void Flip(){
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1; 
        transform.localScale = scaler;
    }
}
