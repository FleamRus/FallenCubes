using System;
using System.Collections;
using UnityEngine;

public class TimerLife : MonoBehaviour
{
    [SerializeField] private int _minValueLife;
    [SerializeField] private int _maxValueLife;

    public void StartTimer(Action onFinished)
    {
        float lifeTime = UnityEngine.Random.Range(_minValueLife, _maxValueLife);

        StartCoroutine(TimerCoroutine(lifeTime, onFinished));
    }

    private IEnumerator TimerCoroutine(float seconds, Action onFinished)
    {
        yield return new WaitForSeconds(seconds);
        onFinished?.Invoke();
    }
}
