using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveAction;
    [SerializeField] private InputActionReference _sprintAction;
    
    private Rigidbody2D _rigidbody2D;
    public float moveSpeed = 1.0f;
    public float sprintSpeed = 1.6f;
    private float _currentSpeed;
    
    private bool _canMove = true;
    private bool _isSprinting = false;

    private Vector2 _movement;
    private Vector2 _input;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _sprintAction.action.started += ctx => _isSprinting = true;
        _sprintAction.action.canceled += ctx => _isSprinting = false;
    }

    void Update()
    {
        _currentSpeed = _isSprinting ? sprintSpeed : moveSpeed;
        
        
        
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
        
        _input = _moveAction.action.ReadValue<Vector2>();
    }

    private void HandleMovement()
    {
        _movement = _input;
        _movement.Normalize();

        _movement *= _currentSpeed * 100 * Time.deltaTime;

        _rigidbody2D.linearVelocity = _movement;
    }

    public void ToggleMovement()
    {
        _canMove = !_canMove;
    }
}
