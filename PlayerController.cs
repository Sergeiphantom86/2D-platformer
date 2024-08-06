using UnityEngine;

[RequireComponent(typeof(Direction), typeof(Mover), typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundDetector))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 400f;

    private Mover _mover;
    private Rigidbody2D _rigidbody;
    private Direction _reversalView;
    private GroundDetector _checkGrounded;
    private bool _grounded;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _reversalView = GetComponent<Direction>();
        _checkGrounded = GetComponent<GroundDetector>();
    }

    private void Update()
    {
        _grounded = _checkGrounded.CheckLocationOnGround();
    }

    public void Move(float move, bool jump)
    {
        _mover.Walk(move);

        _reversalView.FlipCharacter(move);

        JumpHandler(jump);
    }

    private void JumpHandler(bool jump)
    {
        if (_grounded && jump)
        {
            _grounded = false;
            _rigidbody.AddForce(new Vector2(0, _jumpForce));
        }
    }
}