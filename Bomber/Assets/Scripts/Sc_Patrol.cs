using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sc_Patrol : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform playerTr;
    private int randomSpot;
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {
        agent.SetDestination(playerTr.position);
    }
}
