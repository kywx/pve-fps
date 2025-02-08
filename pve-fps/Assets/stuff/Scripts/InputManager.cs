using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    private Vector2 movementInput;

    private PlayerMotor motor;
    private PlayerLook look;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx => motor.Jump();

        onFoot.Sprint.performed += ctx => motor.Sprint();
        onFoot.Sprint.canceled += ctx => motor.SprintOff();

        //onFoot.ToggleHairdryer.performed += ctx => motor.Hairdry();  // for click logic

        // for on hold/release logic
        onFoot.ToggleHairdryer.performed += ctx => motor.HairdryON();
        onFoot.ToggleHairdryer.canceled += ctx => motor.HairdryOFF();
    }

    private void Update()
    {
        // tell the playermotor to move using the value fm our movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    // Update is called once per frame
    //void FixedUpdate()
    //{
    //    // tell the playermotor to move using the value fm our movement action
    //    motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    //}

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());

    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}

