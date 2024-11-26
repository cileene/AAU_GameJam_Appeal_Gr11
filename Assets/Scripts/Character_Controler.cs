using UnityEngine;

public class Character_Controler : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpForce = 5f;
    private Rigidbody _rb;
    private float hInput;
    private Vector3 mDirection;
    private bool jumpKey;
    private bool isGrounded;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpKey = true;
        }

    
    }

    void FixedUpdate()
    {
        if (jumpKey)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            jumpKey = false;
        }

        hInput = Input.GetAxis("Horizontal");
        mDirection = new Vector3(hInput, 0, 0) * moveSpeed;
        _rb.AddForce(mDirection, ForceMode.VelocityChange);

       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
       
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
