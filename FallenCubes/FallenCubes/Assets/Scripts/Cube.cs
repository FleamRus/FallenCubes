using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;

    private bool _hasToouchPlanform;
    private Coroutine _lifeCoroutine;
    private Rigidbody _rigidbody;

    public event Action<Cube> HasTouchPlatform;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_hasToouchPlanform)
            return;

        if (collision.gameObject.GetComponent<Plane>())
        {
            _hasToouchPlanform = true;

            _colorChanger.SetRandomColor();

            HasTouchPlatform?.Invoke(this);
        }
    }

    public void ResetState(Color color)
    {
        _hasToouchPlanform = false;

        if (_lifeCoroutine != null)
        {
            StopCoroutine(_lifeCoroutine);
            _lifeCoroutine = null;
        }

        _colorChanger.SetBaseColor(color);

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
