using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private float _damageCount = 10f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            other.GetComponent<Destination>().health -= _damageCount;
        }
    }
}
