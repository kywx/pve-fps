using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleMovementState(int state)
    {
        _animator.SetInteger("MovementState", state);
    }

}
