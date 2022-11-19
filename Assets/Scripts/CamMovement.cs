using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.Serialization;

public class CamMovement : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;
    [SerializeField] private GameObject target;
    [FormerlySerializedAs("_multiplier")] [SerializeField] private float multiplier = 2f;
    private Transform _selfTransform;
    private Vector3 _offset;
    // Start is called before the first frame update
    void Start()
    {
        _selfTransform = GetComponent<Transform>();
        _offset = new Vector3(-5, 0, -5);
    }

    // Update is called once per frame
    void Update()
    {
        //_horizontal = Input.GetAxisRaw("Horizontal");
        //_vertical = Input.GetAxisRaw("Vertical");

        //transform.position += new Vector3(_horizontal * multiplier, 0, _vertical*multiplier);
        
    }

    private void LateUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        var position = target.transform.position;
        var newPos = new Vector3(position.x + _offset.x, _selfTransform.position.y, position.z + _offset.z);
        _selfTransform.position = Vector3.Lerp(_selfTransform.transform.position, newPos, Time.deltaTime);
    }
}
