using UnityEngine;

public class PlayerColliding : MonoBehaviour
{
    private CharacterController characterController;
    public float pushPower = 2.0f;
    public float pushRecieve = 5.0f;
    public float mass = 10.0f;
    private Vector3 pushVelocity;

    private void Start()
    {
        pushVelocity = Vector3.zero;
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (pushVelocity != Vector3.zero)
        {
            characterController.Move(pushVelocity * Time.deltaTime);
            // reduce, if negative, go to zero
            if (pushVelocity.x != 0)
            {
                pushVelocity.x -= 2* mass * Time.deltaTime;
            }
            if (pushVelocity.y != 0)
            {
                pushVelocity.y -= mass * Time.deltaTime;
            }
            if (pushVelocity.z != 0)
            {
                pushVelocity.z -= 2 * mass * Time.deltaTime;
            }
            
            if (pushVelocity.x < 0)
            {
                pushVelocity.x = 0;
            }
            if (pushVelocity.y < 0)
            {
                pushVelocity.y = 0;
            }
            if (pushVelocity.z < 0)
            {
                pushVelocity.z = 0;
            }
            Debug.Log(pushVelocity);
        }
    }

    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    // add collison effect so player can push objects
    //    Rigidbody body = hit.collider.attachedRigidbody;

    //    // no rigidbody
    //    if (body == null || body.isKinematic)
    //    {
    //        return;
    //    }

    //    // We dont want to push objects below us
    //    if (hit.moveDirection.y < -0.3)
    //    {
    //        return;
    //    }
    //    Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
    //    body.AddForce(pushDir * pushPower);
    //}

    private void OnCollisionEnter(Collision collision)
    {
        // only if enemy 
        if (collision.gameObject.tag == "Enemy")
        {
            Vector3 mask = new Vector3(1,0.3f,1);  // less vertical force
            Vector3 pushDir = Vector3.Scale(collision.transform.forward, mask);
            pushVelocity = pushDir * pushRecieve * 3.0f;
            Debug.Log(pushVelocity);

        }
    }
}
