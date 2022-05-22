using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoxMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position += _speed * Time.deltaTime * Vector3.forward;
    }
}
