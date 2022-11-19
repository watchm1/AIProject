using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    private AI aıScript;
    public GameObject[] points;
    private int currentTarget;
    void Start()
    {
        currentTarget = 0;
        aıScript = GameObject.Find("AI-1").GetComponent<AI>();
        aıScript._agent.SetDestination(points[currentTarget].transform.position);
    }

    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {

            if (currentTarget==3)
            {
                currentTarget = 0;
                aıScript._agent.SetDestination(points[currentTarget].transform.position);

            }
            else
            {
                currentTarget++;
                aıScript._agent.SetDestination(points[currentTarget].transform.position);

            }

        }
    }
}
