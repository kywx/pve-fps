using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class HairdryerController : MonoBehaviour
{
    ParticleSystem ps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        var main = ps.main;  // literally everything
        var em = ps.emission;  // # of wind particles
        var col = ps.collision;  // wind power
        var vel = ps.velocityOverLifetime;  // wind speed
        var lim = ps.limitVelocityOverLifetime;  // wind cap release
    }

    public void increaseStrength(float someValue)
    {
        // increase collider force
        var col = ps.collision;
        col.colliderForce += someValue;  // particles add more force
    }

    public void decreaseStrength(float someValue)
    {
        // decrease collider force
        var col = ps.collision;
        col.colliderForce -= someValue;  // particles have less force
    }

    public void increaseRange(float someValue)
    {
        var main = ps.main;
        main.startLifetimeMultiplier += someValue;  // increase particle life
    }

    public void decreaseRange(float someValue)
    {
        var main = ps.main;
        main.startLifetimeMultiplier -= someValue;  // decrease particle life
    }

    public void increaseWindSpeed(float someValue)
    {
        var main = ps.main;
        main.startSpeedMultiplier += someValue;  // particles fly out faster

        var em = ps.emission;
        em.rateOverTimeMultiplier += someValue/2;  // more particles fly out per sec
    }

    public void decreaseWindSpeed(float someValue)
    {
        var main = ps.main;
        main.startSpeedMultiplier -= someValue;  // particles fly out slower

        var em = ps.emission;
        em.rateOverTimeMultiplier -= someValue / 2;  // less particles fly out per sec
    }

}
