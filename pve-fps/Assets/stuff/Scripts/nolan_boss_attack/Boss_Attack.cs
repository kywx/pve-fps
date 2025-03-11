using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    public Transform player;
    public GameObject ThrownHat;
    public Transform hatSpawn;
    public float timer = 5f;
    public float hatSpeed = 10f;

    private float bulletTime;
    private bool isShooting;

    // Called by the animation event
    public void StartShooting()
    {
        isShooting = true;
    }

    // Called by another animation event to stop shooting
    public void StopShooting()
    {
        isShooting = false;
    }

    void Update()
    {
        if (!isShooting) return;
        bulletTime -= Time.deltaTime;
        if (bulletTime > 0) return;
        bulletTime = timer;

        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        GameObject hat = Instantiate(ThrownHat, hatSpawn.position, Quaternion.identity);
        HatMovement hatMovement = hat.AddComponent<HatMovement>();

        // Calculate the direction only once
        Vector3 direction = (player.position - hatSpawn.position).normalized;
        hatMovement.Initialize(direction, hatSpeed);
    }
}
