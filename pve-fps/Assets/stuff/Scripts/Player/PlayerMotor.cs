using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private ParticleSystem part;
    private Vector3 playerVelocity;
    private bool isGrounded;
    //private bool sprinting;
    //private bool isHairdrying;  // for click logic

    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        part = GetComponentInChildren<ParticleSystem>();
        //sprinting = false;
        //isHairdrying = false; for click logic
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Sprint()
    {
        //if (sprinting)
        //{
        //    speed = 8;
        //} else
        //{
        //    speed = 5;
        //}
        //sprinting = !sprinting;
        speed = 8;
    }

    public void SprintOff()
    {
        speed = 5;
    }

    //public void Hairdry()
    //{
    //    // for click logic
    //    if (isHairdrying)
    //    {
    //        part.Stop();
    //    } else
    //    {
    //        part.Play();
    //    }
    //    isHairdrying = !isHairdrying;
    //}

    public void HairdryON()
    {
        part.Play();
    }

    public void HairdryOFF()
    {
        part.Stop();
    }
}
