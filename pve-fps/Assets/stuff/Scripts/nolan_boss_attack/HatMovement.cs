using UnityEngine;

public class HatMovement : MonoBehaviour
{
    private Vector3 moveDirection;
    private float speed;

    public void Initialize(Vector3 direction, float speed)
    {
        this.moveDirection = direction;
        this.speed = speed;

        // Set the hat to face the direction of movement
        transform.rotation = Quaternion.LookRotation(direction);

    }

    void Update()
    {
        // Move the hat forward in the set direction
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    // Detect collision with the player using a trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
