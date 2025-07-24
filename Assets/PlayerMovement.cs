using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce = 2f;

    public Transform orientation;
    public AudioSource JumpSound, CollisionGround;

    float horizontalInput;
    float verticalInput;
    public bool IsJumping;

    Vector3 moveDirection;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        JumpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

    void FixedUpdate()
    {
        MovePlayer();
        JumpPlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
    }

    private void JumpPlayer()
    {
        if (Input.GetMouseButton(0) && !IsJumping)
        {
            JumpSound.Play();
            rb.AddForce(new Vector3(0, jumpForce * 2f, 0), ForceMode.Impulse);
            IsJumping = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
            CollisionGround.Play();
        }
    }
}
