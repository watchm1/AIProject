using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        agent.SetDestination(target.transform.position);
    }
    
}
