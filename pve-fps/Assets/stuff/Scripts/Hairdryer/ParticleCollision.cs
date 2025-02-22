using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    // i am very much not using this script


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    public float forceMultiplier = 1;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;
        while (i < numCollisionEvents)
        {
            if (rb)
            {
                Vector3 pos = collisionEvents[i].intersection;
                Vector3 force = collisionEvents[i].velocity * 10;
                rb.AddForce(force * forceMultiplier);
            }
            i++;
        }
    }
}
