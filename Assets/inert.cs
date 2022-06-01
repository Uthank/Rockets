using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class inert : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float forceMod = .5f;

    
    
    private void Update()
    {
        var direction = _target.position - transform.position;

        var force = direction.magnitude * direction.magnitude * forceMod;
        
        //transform.position = Vector3.MoveTowards()
    }
}
