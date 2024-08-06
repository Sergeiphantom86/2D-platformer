using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Mover : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _speed;

    private void Start()
    {
        _speed = 10;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Walk(float speed)
    {
        _rigidbody.velocity = Vector2.MoveTowards(_rigidbody.velocity, GetTarget(speed), _speed);
    }

    private Vector2 GetTarget(float move)
    {
        Vector2 target = new(move * _speed, _rigidbody.velocity.y);

        return target;
    }
}