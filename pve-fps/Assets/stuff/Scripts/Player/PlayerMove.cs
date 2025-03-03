using UnityEngine;
using UnityEngine.Audio;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;
    private ParticleSystem part;

    [SerializeField]
    private AudioSource hairdryerStart;
    [SerializeField]
    private AudioSource hairdryerLoop;
    [SerializeField]
    private AudioSource hairdryerEnd;

    private Vector3 playerVelocity;
    private bool isGrounded;

    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;

    private bool hairDryerOn;
    private bool hairDryerLoopOn;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        part = GetComponentInChildren<ParticleSystem>();
        hairDryerOn = false;
        hairDryerLoopOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (hairDryerOn && !hairDryerLoopOn && hairdryerLoop != null && hairdryerStart != null && !hairdryerStart.isPlaying)
        {
            // if hairdryer is on and the start audio ends, play the loop
            hairdryerLoop.Play();
            hairDryerLoopOn = true;
        }
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
        speed = 8;
    }

    public void SprintOff()
    {
        speed = 5;
    }

    public void HairdryON()
    {
        part.Play();
        hairDryerOn = true;
        if (hairdryerStart != null)
        {
            hairdryerStart.Play();
        }
    }

    public void HairdryOFF()
    {
        part.Stop();
        hairDryerOn = false;
        if (hairdryerLoop != null)
        {
            hairdryerLoop.Stop();
            hairDryerLoopOn = false;
            if (hairdryerEnd != null)
            {
                hairdryerEnd.Play();
            }
        }
    }
}
