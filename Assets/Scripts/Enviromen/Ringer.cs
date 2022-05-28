using System.Collections.Generic;
using UnityEngine;

public class Ringer : MonoBehaviour
{
    [SerializeField] private Ring _ring;
    [SerializeField] private int _count = 5;
    [SerializeField] private float _frequency = 1;
    
    private Queue<Ring> _rings = new Queue<Ring>();
    private float _breakpoint;

    private void Awake()
    {
        for (int i = 0; i < _count; i++)
        {
            _rings.Enqueue(Instantiate(_ring, new Vector3(transform.position.x, transform.position.y, i * _frequency), Quaternion.identity));
        }

        _breakpoint = _frequency;
    }

    private void Update()
    {
        if (transform.position.z > _breakpoint)
        {
            _breakpoint += _frequency;
            var ring = _rings.Dequeue();
            ring.transform.position += Vector3.forward * _frequency * _count;
            ring.ResetAlpha();
            _rings.Enqueue(ring);
        }
    }
}
