using UnityEngine;

public class BossLife : MonoBehaviour
{
    [SerializeField] EnemyStats _stats;

    private float _health;
    void Start()
    {
        float extraHealth = GameObject.FindGameObjectWithTag("Stats").GetComponent<BossStatTracker>()._extraHealth;
        _health = _stats.health + extraHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        _health -= dmg;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Invoke("DestroyEnemy", 0.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        
        
        TakeDamage(other.GetComponent<PlayerWeapon>().weaponDamage);
        
    }
}
