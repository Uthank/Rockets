using System;
using System.Collections;
using UnityEngine;

public class UIEffectJump : MonoBehaviour
{
    [SerializeField] private float _duration = 1/3f;
    [SerializeField] private AnimationCurve _animation;

    private float _speed;

    private void Awake()
    {
        _speed = 1 / _duration;
    }

    private void OnEnable()
    {
        StartCoroutine(Jump());
    }

    private IEnumerator Jump()
    {
        for (float i = 0; i < 1; i += Time.deltaTime * _speed)
        {
            transform.localScale = Vector3.one * _animation.Evaluate(i);
            yield return null;
        }

        transform.localScale = Vector3.one;
    }
}
