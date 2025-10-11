using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerConttroller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    private Vector2 _movementAxis;
    private Rigidbody2D _rb;
    private bool _isGrounded;
    private int _jumpCounter = 1;
    private bool _isJumping = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        _isGrounded = Physics2D.Linecast(transform.position, transform.position + transform.up * -1, groundLayer);
    }

    private void Moving()
    {
        transform.Translate(new Vector3(_movementAxis.x * speed *Time.deltaTime,0,0),Space.Self);
    }

    public void MoveAxis(InputAction.CallbackContext context)
    {
        _movementAxis = context.ReadValue<Vector2>();
    }

    public void JumpButton(InputAction.CallbackContext context)
    {
        if (_isGrounded)
        {
            _rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
            _isJumping = false;
        }
        else if(!_isJumping)
        {
            _rb.linearVelocity = Vector2.zero;
            _rb.AddForce(Vector2.up * jumpForce * 2,ForceMode2D.Impulse);
            _isJumping = true;
        }
    }
}
