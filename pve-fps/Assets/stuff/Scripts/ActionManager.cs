using UnityEngine;
using UnityEngine.InputSystem;

public class ActionManager : MonoBehaviour
{
    private PlayerAction playerAction;
    public PlayerAction.OnFootActions onFoot;
    private Vector2 movementInput;

    private PlayerMove p_move;
    private PlayerCam p_cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerAction = new PlayerAction();
        onFoot = playerAction.OnFoot;

        p_move = GetComponent<PlayerMove>();
        p_cam = GetComponent<PlayerCam>();

        onFoot.Jump.performed += ctx => p_move.Jump();

        onFoot.Sprint.performed += ctx => p_move.Sprint();
        onFoot.Sprint.canceled += ctx => p_move.SprintOff();

        //onFoot.ToggleHairdryer.performed += ctx => motor.Hairdry();  // for click logic

        // for on hold/release logic
        onFoot.ToggleHairdryer.performed += ctx => p_move.HairdryON();
        onFoot.ToggleHairdryer.canceled += ctx => p_move.HairdryOFF();
    }

    private void Update()
    {
        // tell the playermotor to move using the value fm our movement action
        p_move.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    // Update is called once per frame
    //void FixedUpdate()
    //{
    //    // tell the playermotor to move using the value fm our movement action
    //    motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    //}

    private void LateUpdate()
    {
        p_cam.ProcessLook(onFoot.Look.ReadValue<Vector2>());

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

