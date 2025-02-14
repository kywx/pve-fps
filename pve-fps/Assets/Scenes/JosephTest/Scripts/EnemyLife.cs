using Unity.VisualScripting;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private EnemyHat _hat;
    [SerializeField] EnemyStats _stats;
    void Start()
    {
        _stats.health = 30;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        _stats.health -= dmg;
        if (_stats.health <= 0)
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
        if (collision.gameObject.tag == "Player")
        {
            TakeDamage(10);
        }
    }

}
