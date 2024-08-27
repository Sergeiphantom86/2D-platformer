using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _coinsPrefab;
    [SerializeField] private float _respawnDuration;

    private Coin _coin;
    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_respawnDuration);
    }

    private void OnEnable()
    {
        _coin = Instantiate(_coinsPrefab, _coinsPrefab.transform.position, quaternion.identity);

        _coin.Collected += Respawn;
    }

    private void OnDisable()
    {
        _coin.Collected -= Respawn;
    }

    private void Respawn()
    {
        StartCoroutine(SpawnCoinWithDelay());
    }

    private IEnumerator SpawnCoinWithDelay()
    {
        yield return _wait;

        _coin.gameObject.SetActive(true);
        _coin.SetPosition(GetPosition());
    }

    private Vector2 GetPosition(int minPositionX = -10, int maxPositionX = 6, int positionY = -3)
    {
        return new Vector2(UnityEngine.Random.Range(minPositionX, maxPositionX), positionY);
    }
}