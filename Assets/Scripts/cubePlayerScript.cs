using UnityEngine;
using UnityEngine.InputSystem;

public class CubePlayerScript : MonoBehaviour
{
    public InputActionAsset InputAsset;
    private InputAction moveAction;
    private InputAction lookAction;

    private Vector2 moveamt;
    private Vector2 lookamt;
    private Animator animator;
    private Rigidbody2D rb;

    public float movespeed = 6;
    public float lookspeed = 4;

    private void OnEnable()
    {
        var playerActionMap = InputAsset.FindActionMap("Player");
        moveAction = playerActionMap.FindAction("Move");
        lookAction = playerActionMap.FindAction("Look");
        
        playerActionMap.Enable();
    }

    private void OnDisable()
    {
        InputAsset.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
        rb.gravityScale = 0;
    }

    private void Update()
    {
        moveamt = moveAction.ReadValue<Vector2>();
        lookamt = lookAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Walking();
    }

    private void Walking()
    {
        // // Set animator parameter based on movement magnitude
        // animator.SetFloat("Speed", moveamt.magnitude);
        
        // Move the player
        Vector2 movement = moveamt.normalized * movespeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    
}