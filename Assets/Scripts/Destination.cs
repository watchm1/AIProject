using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Destination : MonoBehaviour
{
    private AI[] _aiScripts;
    public GameObject[] points;
    private int _currentTarget;
    private NavMeshAgent _selfNavmesh;
    private void Start()
    {
        _currentTarget = 0;
        _aiScripts = FindObjectsOfType<AI>();
        HandleAllDestinations();
        _selfNavmesh = GetComponent<NavMeshAgent>();
        _selfNavmesh.speed = 10f;
    }

    private void Update()
    {
        _selfNavmesh.SetDestination(points[_currentTarget].transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            
            if (_currentTarget == points.Length -1)
            {
                _currentTarget = 0;
            }
            else
            {
                _currentTarget = Random.Range(0, points.Length-1);
            }
            HandleAllDestinations();
            Debug.Log("Current index" + _currentTarget);
        }
    }

    private void HandleAllDestinations()
    {
        foreach (var ai in _aiScripts)
        {
            ai.agent.SetDestination(points[_currentTarget].transform.position);
        }
    }
}
