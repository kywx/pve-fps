using UnityEngine;

public class PlayerColliding : MonoBehaviour
{
    private CharacterController characterController;
    public float pushPower = 2.0f;
    public float pushRecieve = 10.0f;
    public float mass = 5.0f;
    private Vector3 pushVelocity;
    

    private void Start()
    {
        pushVelocity = Vector3.zero;
        characterController = GetComponent<CharacterController>();
        PlayerInteract.AddDamage += DamageIncrease;
    }

    private void Update()
    {
        if (pushVelocity != Vector3.zero)
        {
            characterController.Move(pushVelocity * Time.deltaTime);
            //pushVelocity = Vector3.MoveTowards(pushVelocity, Vector3.zero, 2 * mass * Time.deltaTime);  // this one is different for some reason
            pushVelocity.x = Mathf.MoveTowards(pushVelocity.x, 0, Time.deltaTime * mass * 2);
            pushVelocity.y = Mathf.MoveTowards(pushVelocity.y, 0, Time.deltaTime * mass * 2);
            pushVelocity.z = Mathf.MoveTowards(pushVelocity.z, 0, Time.deltaTime * mass * 2);
            pushVelocity.y = (pushVelocity.y <= 0.1) ? 0 : pushVelocity.y;
            pushVelocity.x = (pushVelocity.y==0) ? (Mathf.Max(pushVelocity.x - Time.deltaTime * mass * 2, 0f)) : pushVelocity.x;
            pushVelocity.z = (pushVelocity.y==0) ? (Mathf.Max(pushVelocity.z - Time.deltaTime * mass * 2, 0f)) : pushVelocity.z;
            Debug.Log(pushVelocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // only if enemy 
        if (collision.gameObject.tag == "Enemy")
        {
            Vector3 mask = new Vector3(1,0.3f,1);  // less vertical force
            Vector3 pushDir = Vector3.Scale(collision.transform.forward.normalized, mask);
            pushVelocity = pushDir * pushRecieve * 3.0f;  // push receive can change based on the number of hats
            Debug.Log(pushVelocity);
        }
    }
    void DamageIncrease()
    {
        pushPower++;
    }
}
