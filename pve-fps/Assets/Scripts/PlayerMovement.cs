using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Movement")]
    private float movementSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool canJump = true;


    [Header("Ground Detection")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool isGrounded;


    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public Transform orientation;
    Vector3 moveDirection;
    float horizontalInput;
    float verticalInput;

    Rigidbody rb;

    public MovementState state; // stores the current movement state of the player (are they sprinting, walking, etc.)
    public enum MovementState {
        Walking,
        Sprinting,
        Air
    }

    private void StateHandler() {
        // check if the player is grounded, sprinting, or in the air
        if(isGrounded && Input.GetKey(sprintKey)) {
            state = MovementState.Sprinting;
            movementSpeed = sprintSpeed;
        } else if (!isGrounded) {
            state = MovementState.Air;
        } else {
            state = MovementState.Walking;
            movementSpeed = walkSpeed;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void MyInput() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && canJump && isGrounded) {
            Jump();
            canJump = false;
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer() {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);

        if (isGrounded) {
            rb.AddForce(moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);
        } else {
            rb.AddForce(moveDirection.normalized * movementSpeed * airMultiplier * 10f, ForceMode.Force);
        }
    }

    private void SpeedControl() {
        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // If the player goes faster than the movementSpeed, we limit the speed to the maximum velocity
        if (flatVelocity.magnitude > movementSpeed) {
            Vector3 limitedVelocity = flatVelocity.normalized * movementSpeed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
        }
    }

    private void Jump() {
        //reset y velocity to ensure that the jump is consistently at the same height
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump() {
        canJump = true;
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        SpeedControl();
        StateHandler();

        // Check if player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        // Apply drag
        if (isGrounded) {
            rb.linearDamping = groundDrag;
        } else {
            rb.linearDamping = 0;
        }
    }
}
