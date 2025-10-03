using System.Collections.Generic;
using UnityEngine;

public class PoolCube : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _initialSize;

    private Transform _poolContainer;
    private Queue<Cube> _cubeQueue;

    public bool HasAvailable => _cubeQueue.Count > 0;

    private void Awake()
    {
        GameObject container = new("PoolContainer");
        _poolContainer = container.transform;
        _poolContainer.parent = transform;

        _cubeQueue = new Queue<Cube>();

        for (int i = 0; i < _initialSize; i++)
        {
            Cube cube = Instantiate(_cubePrefab, _poolContainer);

            cube.gameObject.SetActive(false);

            _cubeQueue.Enqueue(cube);
        }
    }

    public Cube GetCube()
    {
        Cube cube;

        cube = _cubeQueue.Dequeue();
        cube.gameObject.SetActive(true);

        return cube;
    }

    public void ReturnCube(Cube cube)
    {
        cube.gameObject.SetActive(false);
        cube.transform.SetParent(_poolContainer);
        _cubeQueue.Enqueue(cube);
    }
}
