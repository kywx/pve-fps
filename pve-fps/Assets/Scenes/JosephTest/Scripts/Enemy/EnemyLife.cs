using Unity.VisualScripting;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private EnemyHat _hat;
    [SerializeField] EnemyStats _stats;

    private float _health;
    void Start()
    {
        _health = _stats.health;
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
        _hat.LaunchHat();
       // Destroy(gameObject);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            TakeDamage(10);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        
        
        TakeDamage(other.GetComponent<PlayerWeapon>().weaponDamage);
        
    }

}
