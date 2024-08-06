using UnityEngine;

[RequireComponent(typeof(Direction), typeof(Mover))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Direction _reversalView;
    private Mover _mover;
    private bool _leftmostPoint;
    private float _horizontalMove = 10;
    private int _targetPosition = 0;
    public const string Speed = nameof(Speed);

    private void Awake()
    {
        _targetPosition = GetRandomTarget(_targetPosition);
        _reversalView = GetComponent<Direction>();
        _mover = GetComponent<Mover>();
    }

    private void FixedUpdate()
    {
        Move();

        _animator.SetFloat(Speed, Mathf.Abs(_horizontalMove));
    }

    private void Move()
    {
        float speed = 0.2f;
        float minMileageLength = 5;

        if (_leftmostPoint == false)
        {
            _mover.Walk(speed);

            if (transform.position.x > _targetPosition + minMileageLength)
            {
                _leftmostPoint = true;
                _reversalView.FlipCharacter(-speed);
                _targetPosition = GetRandomTarget();
            }
        }
        else if (_leftmostPoint)
        {
            _mover.Walk(-speed);

            if (_targetPosition > transform.position.x)
            {
                _leftmostPoint = false;
                _reversalView.FlipCharacter(speed);
                _targetPosition = GetRandomTarget();
            }
        }
    }

    private int GetRandomTarget(int minPositionX = -10, int maxPositionX = 0)
    {
        return Random.Range(minPositionX, maxPositionX);
    }
}