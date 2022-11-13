using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class nav : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;

    [SerializeField] private GameObject target;
    private void Start()
    {
        _navMeshAgent.SetDestination(target.transform.position);
    }
}
