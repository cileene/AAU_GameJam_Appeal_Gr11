using UnityEngine;

public class Character_Controler : MonoBehaviour
{
    public float moveSpeed = 1f;
    //public float jumpForce = 3f;
    private Rigidbody _rb;
    private float hInput;
    private Vector3 mDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // vi burger FixedUpdate for at 
    void FixedUpdate()
    {
        hInput = Input.GetAxis("Horizontal");

        mDirection = new Vector3(hInput, 0, 0) * moveSpeed;

        _rb.AddForce(mDirection, ForceMode.VelocityChange);
    }
}
