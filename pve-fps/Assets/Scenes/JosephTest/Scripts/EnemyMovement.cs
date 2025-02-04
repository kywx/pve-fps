using UnityEngine;
using UnityEngine.AI;


public enum MovementState
{
    Idle, Patrol, Chase
}
public class EnemyMovement : MonoBehaviour
{

   // private MovementState _movementState;
    [SerializeField] NavMeshAgent _enemy;
    [SerializeField] Transform _target;
private void Start() 
{
    //_movementState = MovementState.Patrol;
}    

void Update()
    {
       /* if (_movementState == MovementState.Patrol)
        {
            
        } */

        if (_target != null)
        {
            _enemy.SetDestination(_target.position);
        }
    }
}
