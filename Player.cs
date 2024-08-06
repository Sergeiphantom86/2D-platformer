using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _runSpeed = 40f;

    private float _horizontalMove = 0;
    private bool _jump = false;
    public const string Speed = nameof(Speed);
    public const string Horizontal = nameof(Horizontal);
    public const string Jump = nameof(Jump);

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
        _controller.Move(_horizontalMove * Time.fixedDeltaTime, _jump);

        _jump = false;
    }
}