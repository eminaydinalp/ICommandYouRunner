using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Spawnn : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;

    [SerializeField] private List<NavMeshAgent> _navMeshAgents;


    private void Start()
    {
       
    }

    private void Update()
    {
        /*foreach (var navMeshAgent in _navMeshAgents)
        {
            navMeshAgent.destination = (transform.position);
        }*/
        
        RandomPos();
        
        transform.parent.Translate(transform.parent.forward * 10 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateBall();
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            Deleteee(10);
        }
        
    }

    private void CreateBall()
    {
        for (int i = 0; i < 10; i++)
        {
            NavMeshAgent navMeshAgent = Instantiate(_navMeshAgent, transform.position, Quaternion.identity, transform);
            
            _navMeshAgents.Add(navMeshAgent);

            //navMeshAgent.destination = transform.position +  Random.insideUnitSphere;

        }
    }

    private void RandomPos()
    {
        
        foreach (var navMeshAgent in _navMeshAgents)
        {
            navMeshAgent.SetDestination(transform.position + Random.insideUnitSphere);
        }
    }
    
    private void Deleteee(int number)
    {
        for (int i = 0; i < number; i++)
        {

            NavMeshAgent navMeshAgent =_navMeshAgents[_navMeshAgents.Count -1];
            _navMeshAgents.Remove(navMeshAgent);
            Destroy(navMeshAgent.gameObject);

            //navMeshAgent.destination = transform.position +  Random.insideUnitSphere;

        }
    }

   
}
