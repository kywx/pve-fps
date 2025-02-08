using UnityEngine;

public class PlayerColliding : MonoBehaviour
{
    // i don't know if im actually using this script
    // add collison effect to player because character controller and not rigidbody
    // this script pushes all rigidbodies that the character touches
    public CharacterController characterController;
    public float pushPower = 2.0f;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        //body.velocity = pushDir * pushPower;   // velocity is obsolete or something
        body.AddForce(pushDir * pushPower);
    }
}
