using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Destination : MonoBehaviour
{
    public float health;
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
        health = 100;
    }

    private void Update()
    {
        if (health == 0)
        {
            Time.timeScale = 0;
            //Destroy(gameObject);
        }
        else
        {
            _selfNavmesh.SetDestination(points[_currentTarget].transform.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            _currentTarget = Random.Range(0, points.Length-1);
            HandleAllDestinations();
            
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
