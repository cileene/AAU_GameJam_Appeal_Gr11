using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpForce = 5f;
    private Rigidbody _rb;
    private float _hInput;
    private Vector3 _mDirection;
    private bool _jumpKey;
    private bool _isGrounded;
    private int _groundContacts = 0; // Fix for loosing ground detection
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _jumpKey = true;
        }
    }

    private void FixedUpdate()
    {
        if (_jumpKey)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            _jumpKey = false;
        }

        _hInput = Input.GetAxis("Horizontal");
        _mDirection = new Vector3(_hInput, 0, 0) * moveSpeed;
        _rb.AddForce(_mDirection, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _groundContacts++;
            _isGrounded = true;
            Debug.Log("Grounded - Contacts: " + _groundContacts);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _groundContacts--;
            if (_groundContacts <= 0)
            {
                _isGrounded = false;
                Debug.Log("Not Grounded - Contacts: " + _groundContacts);
            }
        }
    }
}
