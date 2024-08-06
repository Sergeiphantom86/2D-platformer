using System;
using UnityEngine;

[RequireComponent(typeof(GroundDetector), typeof(Rigidbody2D))]

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value;

    private GroundDetector _checkGrounded;
    private Rigidbody2D _rigidbody;

    public int Value => _value;

    public event Action Collected;

    private void Start()
    {
        _checkGrounded = GetComponent<GroundDetector>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        DisableRigidbody();
        _checkGrounded.CheckLocationOnGround();
    }

    public void Collect()
    {
        SetSpawnPosition();

        Collected?.Invoke();
        gameObject.SetActive(false);

        _rigidbody.isKinematic = false;
    }

    private void SetSpawnPosition(int positionY = -3)
    {
        Vector2 tempPosition = transform.position;

        tempPosition.x = GetRandomPosition();
        tempPosition.y = positionY;

        transform.position = tempPosition;
    }

    private int GetRandomPosition(int minPositionX = -10, int maxPositionX = 6)
    {
        return UnityEngine.Random.Range(minPositionX, maxPositionX);
    }

    private void DisableRigidbody()
    {
        if (_checkGrounded.CheckLocationOnGround())
        {
            _rigidbody.isKinematic = true;
            _rigidbody.velocity = Vector2.zero;
        }
    }
}