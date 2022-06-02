using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class Mover : MonoBehaviour
{
    [SerializeField] private MoveBoxMover _moveBox;
    [SerializeField] private float _deviationDistance = 1.5f;
    [SerializeField] private float _tailSpeed;
    [SerializeField] private float _tailLenght = 3f;
    [SerializeField] private float _speed = 10f;
    
    private InputHandler _inputHandler;
    
    private Vector3 _basePosition;
    private Vector3 _tailOffset;
    private Vector3 _tailDirection;
    private Queue<Vector3> _positionHistory = new Queue<Vector3>();
    private float _frequency = .001f;
    private int _tailLag = 10;
    private float _nextTime;
    private Vector3 _nextTailPosition;
    private bool _isActive = true;
    private Vector3 _moveTargetPosition;
    private IEnumerator _move;

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
        if (_isActive == true)
            _moveTargetPosition =
                new Vector3(_inputHandler.PointOnScreen.x, _inputHandler.PointOnScreen.y, 0) * _deviationDistance +
                _basePosition;
        else
            _moveTargetPosition = _basePosition;
        
        if (_move != null)
            StopCoroutine(_move);
            
        _move = Move();
        StartCoroutine(_move);

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

    public void Stop()
    {
        _speed = 1.5f;
        _isActive = false;
        _moveBox.Stop();
    }

    private IEnumerator Move()
    {
        while (transform.localPosition != _moveTargetPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _moveTargetPosition, _speed * Time.deltaTime);
            yield return null;
        }
        
        _move = null;
    }
}
