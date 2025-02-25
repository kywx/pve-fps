using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public enum MovementState
{
    Idle, Wander, Chase
}
public class EnemyMovement : MonoBehaviour
{
    //gotta make this use an event in the future
   // [SerializeField] EnemyAnimations _animation;
    private MovementState _movementState;
    [SerializeField] NavMeshAgent _enemy;

   // [SerializeField] Transform _player;
    [SerializeField] Transform _target;

    [SerializeField] float _chaseSpeed;
    [SerializeField] float _wanderSpeed;

    [SerializeField] float _chaseRange;
    [SerializeField] float _knockback;
    [SerializeField] float _wanderRadius;
    [SerializeField] float _wanderTimer;

    [SerializeField] EnemyStats _stats;

    private float _timer;

private void Start() 
{
    _timer = _wanderTimer;
    _movementState = MovementState.Wander;
    _enemy.speed = _wanderSpeed;
    _target = GameObject.FindWithTag("Player").transform;
    _chaseSpeed = _stats.chaseSpeed;
    _knockback = _stats.knockback;
}    

void FixedUpdate()
    {
        // changes action based off of state
        if (_movementState == MovementState.Wander)
        {
            HandleWander();
        } 
        if (_movementState == MovementState.Chase)
        {
            HandleChase();
        }

        // sets state

        if (Vector3.Distance(_target.position, transform.position) < _chaseRange)
        {
            _movementState = MovementState.Chase;
        }
        else
        {
            _movementState = MovementState.Wander;
        }

       // _animation.HandleMovementState((int)_movementState);
       transform.LookAt(_target);
    }

    private void HandleChase()
    {
        _enemy.speed = _chaseSpeed;
        _enemy.SetDestination(_target.position);
    }
    
    private void HandleWander()
    {
        _enemy.speed = _wanderSpeed;
        _timer += Time.deltaTime;

        if (_timer > _wanderTimer)
        {
            Vector3 newPosition = RandomNavSphere(transform.position, _wanderRadius, -1);
            _enemy.SetDestination(newPosition);
            _timer = 0;
        }
    }

    // takes enemy's current position and then returns a new position scaled with its _wanderRadius
    private Vector3 RandomNavSphere(Vector3 origin, float distance, int layerMask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance; 

        randomDirection += origin;
        
        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layerMask);

        return navHit.position;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player")   
        {
            //other.transform.GetComponent<Rigidbody>().AddForce(transform.forward * -1 * _knockback, ForceMode.Impulse);
            //other.gameObject.GetComponent<CharacterController>().Move(transform.forward * -1 * _knockback * Time.deltaTime);
            //Debug.Log(transform.forward * -1 * _knockback * Time.deltaTime);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Transform particleDirection = other.transform;
        
        GetComponent<Rigidbody>().AddForce(particleDirection.forward * _stats.knockbackToEnemy);
        
    }

}
