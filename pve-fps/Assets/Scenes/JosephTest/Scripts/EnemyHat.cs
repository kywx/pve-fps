using UnityEngine;

public class EnemyHat : MonoBehaviour
{
    [SerializeField] Transform _hat;
    [SerializeField] Rigidbody _hatRB;

    [SerializeField] GameObject _enemy;
    [SerializeField] float _hatForce;
    [SerializeField] float _hatLifetime;
    [SerializeField] float _maxSpeed;
    //[SerializeField] float _hatAdjust;

    void Start()
    {
        _hatRB.freezeRotation = true;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       /* if (_hatRB.linearVelocity.magnitude > _maxSpeed)
        {
            Vector3 newVelocity = Vector3.one * _maxSpeed;
            _hatRB.linearVelocity = newVelocity;
        } */
       // if(_hat.parent != null)
       // {
         //   _hat.position = new Vector3(transform.position.x, transform.position.y - _hatAdjust, transform.position.z);
       // }
    }

    public void LaunchHat()
    {
        //Vector3 currentPosition = transform.position;
       
        
        if (_enemy != null && _hat.IsChildOf(_enemy.transform))
        {
        //_hat.position = currentPosition;
            _enemy.transform.DetachChildren();
            _hatRB.freezeRotation = false;
            _hat.GetComponent<HingeJoint>().breakForce = _hatForce / 2f;
            _hatRB.AddRelativeForce(Vector3.up * _hatForce, ForceMode.Force);

        
            Invoke("DestroyHat", _hatLifetime);
        }
        


    }

    private void DestroyHat()
    {
        Destroy(_hat.gameObject);
        
    }

    private void OnCollisionEnter(Collision other) 
    {
       /* if (other.gameObject.CompareTag("Player"))
        {
            LaunchHat();
        }
        */
       /* if (other.gameObject.CompareTag("Ground") && transform.parent == null)
        {
            Invoke("DestroyHat", _hatLifetime/2);
        }
        */
    }

    

}
