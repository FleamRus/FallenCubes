using System;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PoolCube _poolCube;
    [SerializeField] private Transform[] _pointsSpawn;
    [SerializeField] private float _spawnTime;
    [SerializeField] private Color _baseColor = Color.red;

    private Cube _cube;

    public event Action<Cube> CubeSpawned;

    private void Start()
    {
        StartCoroutine(SpawnCorutine());
    }

    private IEnumerator SpawnCorutine()
    {
        while (true)
        {
            yield return new WaitUntil(() => _poolCube.HasAvailable);

            SpawnCube();
            yield return new WaitForSeconds(_spawnTime);
        }
    }

    private void SpawnCube()
    {
        int minValueRange = 0;
        int indexPoint = UnityEngine.Random.Range (minValueRange, _pointsSpawn.Length);

        Transform pointSpawn = _pointsSpawn[indexPoint];

        _cube = _poolCube.GetCube();
        _cube.transform.SetPositionAndRotation(pointSpawn.position, Quaternion.identity);

        _cube.ResetState(_baseColor);

        CubeSpawned?.Invoke(_cube);
    }
}
