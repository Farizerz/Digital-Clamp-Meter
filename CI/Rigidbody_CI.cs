using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigidbody_CI : MonoBehaviour
{
    Rigidbody rig_;
    [SerializeField]public float _mass, _angular_drag;

    void Awake()
    {
        rig_ = GetComponent<Rigidbody>();
        _mass = rig_.mass;
        _angular_drag = rig_.angularDrag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
