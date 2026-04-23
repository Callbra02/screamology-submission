using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    
    private Rigidbody2D _rigidbody2D;
    public float moveSpeed = 1.0f;
    
    private bool _canMove = true;

    private Vector2 _movement;
    private Vector2 _input;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleInput()
    {
        if (!_canMove)
            return;
        
        _input = moveAction.action.ReadValue<Vector2>();
    }

    private void HandleMovement()
    {
        _movement = _input;
        _movement.Normalize();

        _movement *= moveSpeed * 100 * Time.deltaTime;

        _rigidbody2D.linearVelocity = _movement;
    }

    public void ToggleMovement()
    {
        _canMove = !_canMove;
    }
}
