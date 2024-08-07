using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Mover : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _speedOfChangeOfSpeed;
    private float _speed = 0;

    private void Start()
    {
        _speed = 10;
        _speedOfChangeOfSpeed = 100;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Walk(float move)
    {
        _rigidbody.velocity = Vector2.MoveTowards(_rigidbody.velocity, GetTargetSpeed(move), _speedOfChangeOfSpeed * Time.fixedDeltaTime);
    }

    private Vector2 GetTargetSpeed(float move)
    {
        return new Vector2(move * _speed, _rigidbody.velocity.y);
    }
}
