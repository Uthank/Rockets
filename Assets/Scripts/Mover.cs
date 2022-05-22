using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _deviationDistance = 1.5f;
    [SerializeField] private float _tailSpeed;
    [SerializeField] private float _tailLenght = 3f;
    
    private InputHandler _inputHandler;
    
    private Vector3 _basePosition;
    private Vector3 _tailOffset;
    private Vector3 _tailDirection;
    private Queue<Vector3> _positionHistory = new Queue<Vector3>();
    private float _frequency = .01f;
    private int _tailLag = 5;
    private float _nextTime;
    private Vector3 _nextTailPosition;

    private void Awake()
    {
        _inputHandler = GetComponent<InputHandler>();
        _basePosition = transform.localPosition;
        _tailOffset = _basePosition;

        for (int i = 0; i < _tailLag; i++)
        {
            _positionHistory.Enqueue(_basePosition);
        }

        _nextTime = Time.time;
    }

    private void Update()
    {
        transform.localPosition = new Vector3(_inputHandler.PointOnScreen.x, _inputHandler.PointOnScreen.y, 0) * _deviationDistance + _basePosition;

        if (Time.time > _nextTime)
        {
            _nextTime = Time.time + _frequency;
            _nextTailPosition = _positionHistory.Dequeue();
            _positionHistory.Enqueue(transform.localPosition);
        }
        
        _tailOffset = Vector3.MoveTowards(_tailOffset, _nextTailPosition, _tailSpeed * Time.deltaTime);
        _tailDirection = (transform.localPosition - new Vector3(_tailOffset.x, _tailOffset.y, _tailOffset.z - _tailLenght)).normalized;
        transform.rotation = Quaternion.FromToRotation(Vector3.forward, _tailDirection);
    }
}
