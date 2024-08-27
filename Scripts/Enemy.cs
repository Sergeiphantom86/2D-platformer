using UnityEngine;

[RequireComponent(typeof(Flipper), typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour
{
    public const string Speed = nameof(Speed);

    [SerializeField] private Animator _animator;

    private Rigidbody2D _enemy;
    private Flipper _flipper;
    private int _targetPosition;
    private float _speed = 1f;

    private void Awake()
    {
        _targetPosition = GetRandomTarget();
        _flipper = GetComponent<Flipper>();
        _enemy = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontalMove = 1;

        Walk();

        _animator.SetFloat(Speed, Mathf.Abs(horizontalMove));

        if (Mathf.Abs(_targetPosition) - Mathf.Abs(transform.position.x) == 0)
        {
            _targetPosition = GetRandomTarget();

            if (transform.position.x > _targetPosition)
            {
                _flipper.FlipCharacter(-horizontalMove);
            }
            else
            {
                _flipper.FlipCharacter(horizontalMove);
            }
        }
    }

    private void Walk()
    {
        _enemy.position = Vector2.MoveTowards(_enemy.position, GetRandomVector(), _speed * Time.fixedDeltaTime);
    }

    private Vector2 GetRandomVector()
    {
        return new Vector2(_targetPosition, transform.position.y);
    }

    private int GetRandomTarget(int minPositionX = -10, int maxPositionX = 0)
    {
        return Random.Range(minPositionX, maxPositionX);
    }
}