using System.Collections;
using UnityEngine;

public class UIEffectRotate : MonoBehaviour
{
    [SerializeField] private float _duration = 1/3f;

    private float _speed;

    private void Awake()
    {
        _speed = 1 / _duration;
    }
    
    private void OnEnable()
    {
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        var _degrees = 180;
        var startRotation = Quaternion.Euler(0, 0, -_degrees);
        var endRotation = Quaternion.Euler(0, 0, 0);
        transform.localRotation = startRotation;
        
        while (transform.localPosition != endRotation.eulerAngles)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, endRotation, _degrees * Time.deltaTime * _speed);
            yield return null;
        }
    }
}
