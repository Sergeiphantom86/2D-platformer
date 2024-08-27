using UnityEngine;

[RequireComponent(typeof(PlayerMover))]

public class Player : MonoBehaviour
{
    public const string Speed = nameof(Speed);

    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Animator _animator;

    private InputReader _inputReader;

    private void Start()
    {
        _inputReader = GetComponent<InputReader>();
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _playerMover.Move(_inputReader.Direction);
        }

        _animator.SetFloat(Speed, Mathf.Abs(_inputReader.Direction));

        if (_inputReader.GetIsJump())
        {
            _playerMover.Jump();
        }
    }
}