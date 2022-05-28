using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _rotationSpeed = 1f;
    
    private Rocket _target;
    private bool _targetKilled = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rocket>(out Rocket target) == true && target == _target)
        {
            target.Damage();
            _target.GetComponent<Rocket>().Killed -= OnTargetKilled;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Move();
        
        if (_targetKilled == false)
            Rotate();
    }

    public void Init(Rocket target)
    {
        _target = target;
        _target.GetComponent<Rocket>().Killed += OnTargetKilled;
    }

    private void Move()
    {
        transform.position += transform.rotation * Vector3.forward * _speed;
    }

    private void Rotate()
    {
        Vector3 direction = _target.transform.position - transform.position;
        transform.rotation =  Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, direction, _rotationSpeed, 0f));
    }

    private void OnTargetKilled()
    {
        _targetKilled = true;
    }
}
