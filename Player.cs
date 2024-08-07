using UnityEngine;

[RequireComponent (typeof(PlayerMover))]

public class Player : MonoBehaviour
{
    public const string Horizontal = nameof(Horizontal);
    public const string Speed = nameof(Speed);
    public const string Jump = nameof(Jump);

    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _runSpeed = 40f;

    private float _horizontalMove = 0;
    private bool _jump = false;

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw(Horizontal) * _runSpeed;

        _animator.SetFloat(Speed, Mathf.Abs(_horizontalMove));

        if (Input.GetButtonDown(Jump))
        {
            _jump = true;
        }
    }

    private void FixedUpdate()
    {
        _playerMover.Move(_horizontalMove * Time.fixedDeltaTime);

        _playerMover.Jump(_jump);

        _jump = false;
    }
}
