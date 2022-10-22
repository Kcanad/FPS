using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
       
    }

       void FixedUpdate()
    {
         
        
          float moveHorizantal =  Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3 (moveHorizantal, 0.0f, moveVertical);
            _rb.AddForce(speed * movement );

        
    
        
    }
}

