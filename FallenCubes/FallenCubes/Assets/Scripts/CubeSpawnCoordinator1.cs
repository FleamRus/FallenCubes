using UnityEngine;

public class CubeSpawnCordinator : MonoBehaviour
{
    [SerializeField] private TimerLife _timerLife;
    [SerializeField] private Cube _cube;
    [SerializeField] private PoolCube _poolCube;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.CubeSpawned += HandleCubeSpawned;
    }

    private void OnDisable()
    {
        _spawner.CubeSpawned -= HandleCubeSpawned;
    }

    private void HandleCubeSpawned(Cube cube)
    {
        cube.HasTouchPlatform += CubeTouchPlatform;
    }

    private void CubeTouchPlatform(Cube cube)
    {
        _timerLife.StartTimer(() => _poolCube.ReturnCube(cube));
    }
}
