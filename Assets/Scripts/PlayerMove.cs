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
    // public Animator animator;
    // [Tooltrip("SpriteRenderer fleep")]
    // public SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private Vector2 moveInput;


    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context){
        moveInput = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
    
}
