using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Sc_Patrol : MonoBehaviour
{
    [SerializeField] private float speed;
    //private float waitTime;
    //[SerializeField] private float starWaitTime;
    //[SerializeField] private Transform[] moveSpots;
    [SerializeField] private Transform playerTr;
    private int randomSpot;

    NavMeshAgent agent;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        //waitTime = starWaitTime;
        //randomSpot = Random.Range(0, moveSpots.Length);
    }
    private void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position,speed * Time.deltaTime );
        //if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2F)
        //{
        //    if(waitTime <= 0)
        //    {
        //        randomSpot = Random.Range(0, moveSpots.Length);
        //        waitTime = starWaitTime;
        //    }
        //}
        //else
        //{
        //    waitTime -= Time.deltaTime;
        //}
        agent.SetDestination(playerTr.position);
    }
}
