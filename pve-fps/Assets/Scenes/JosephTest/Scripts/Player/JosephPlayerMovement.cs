using System.Numerics;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float _moveSpeed;
    [SerializeField] float _groundDrag;
    [SerializeField] float _jumpForce;
    [SerializeField] float _jumpCooldown;
    [SerializeField] float _airMultiplier;
    private bool _canJump;

    [Header("Ground Check")]
    [SerializeField] float _playerHeight;
    [SerializeField] LayerMask _ground;
    private bool _isGrounded;


    [SerializeField] Transform _orientation;
     float _horizontalInput;
     float _verticalInput;

    private UnityEngine.Vector3 _moveDirection;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    void Update()
    {
        _isGrounded = Physics.Raycast(transform.position, UnityEngine.Vector3.down, _playerHeight * 0.5f + 0.2f, _ground); //the numbers are arbitrary but help keep the raycast size contained

        PlayerInput();

        // handle drag/friction
        if (_isGrounded)
        {
            _canJump = true;
            _rb.linearDamping = _groundDrag;
        }
        else 
        {
            _rb.linearDamping = 0; //no friction while airborne
        }
    }

    private void FixedUpdate() 
    {
        // physics are better to apply in fixed update 
        MovePlayer();
    }

    private void PlayerInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        // jump
        if(Input.GetKey(KeyCode.Space) && _isGrounded && _canJump)
        {
            Jump();
            _canJump = false;

            Invoke(nameof(ResetJump), _jumpCooldown); // runs the ResetJump() method after some seconds defined by _jumpCooldown
        }
       
        SpeedControl();
    }

    private void MovePlayer()
    {
        // determine movement direction   -   multiplies x and z axis vectors by player input and adds them to get the final direction
        _moveDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;

        // normalized is used so the input is consistent and doesn't move the player extremely far
        if(_isGrounded)
        {
            _rb.AddForce(_moveDirection.normalized * _moveSpeed * 10f, ForceMode.Force);
        }
        else if(!_isGrounded)
        {
            _rb.AddForce(_moveDirection.normalized * _moveSpeed * 10f * _airMultiplier, ForceMode.Force);
            // makes movement in the air slower or faster depending on the _airMultiplier;
        }
    }

    private void SpeedControl()
    {
        UnityEngine.Vector3 flatVelocity = new UnityEngine.Vector3(_rb.linearVelocity.x, 0f, _rb.linearVelocity.z); // assigns the player's horizontal movement to a vector

        // limit player max speed
        if(flatVelocity.magnitude > _moveSpeed)
        {
            UnityEngine.Vector3 limitedVelocity = flatVelocity.normalized * _moveSpeed; // reduces speed to one, then multiplies/sets it to the max speed
            _rb.linearVelocity = new UnityEngine.Vector3(limitedVelocity.x, _rb.linearVelocity.y, limitedVelocity.z); // horizontal speed gets capped, but NOT vertical speed
        }
    }

    private void Jump()
    {
        // reset y velocity so you jump the same height consistently
        _rb.linearVelocity = new UnityEngine.Vector3(_rb.linearVelocity.x, 0f, _rb.linearVelocity.z);

        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse); // adds force upwards. Impulse applies the force in an instant instead of over time

    }

    private void ResetJump()
    {
        _canJump = true;
    }

}
