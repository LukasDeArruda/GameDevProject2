using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent navAgent;
    public Transform[] points;
    private int pointCount;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, points.Length);
        navAgent.SetDestination(points[random].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            int random = Random.Range(0, points.Length);
            navAgent.SetDestination(points[random].position);
            pointCount++;
        }
    }
}
