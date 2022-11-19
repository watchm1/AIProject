using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class AI : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private bool _canCreate;
    public NavMeshAgent agent;
    public GameObject target;
    private float _defaultAttackDistance;
    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        _defaultAttackDistance = 5f;
        _canCreate = true;
    }

    // Update is called once per frame
    private void Update()
    {
        agent.SetDestination(target.transform.position);

        var distance = Vector3.Distance(transform.position, target.transform.position);
        HandleRotation();
        if (distance <= _defaultAttackDistance)
        {
            AttackToCar();
        }
    }

    private IEnumerator Delay()
    {
        _canCreate = false;
        yield return new WaitForSeconds(2);
        _canCreate = true;
    }
    private void AttackToCar()
    {
        if (_canCreate)
        {
            var obj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody>().AddForce(transform.forward  * 20f, ForceMode.Impulse);
            StartCoroutine(Delay());
        }
    }
    private void HandleRotation()
    {
        var direction = (target.transform.position - transform.position).normalized;
        Quaternion newRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime *5f);
    }
    
}
