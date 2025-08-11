using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{

    [Header("Movement")]
    [Tooltip("Speed horizontal")]
    public float moveSpeed = 5f;

    // [Header("Animator reference")]
    // [Tooltrip("Animator")]
    public Animator animator;
    // [Tooltrip("SpriteRenderer fleep")]
    // public SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private Vector2 moveInput;


    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context){
        animator.SetBool("isMoving", true);
        if (context.canceled)
        {
            animator.SetBool("isMoving", false);
        }

        moveInput = context.ReadValue<Vector2>();
        
        if(moveInput.x < 0 && transform.localScale.x > 0 || moveInput.x > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
    
}
