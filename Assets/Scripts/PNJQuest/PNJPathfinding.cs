using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PNJPathfinding : MonoBehaviour
{

    private GameObject _target;

    private void Start()
    {
        this.gameObject.GetComponent<NavMeshAgent>().radius = 1;
        this.gameObject.GetComponent<NavMeshAgent>().height = 3.5f;
        this.gameObject.GetComponent<NavMeshAgent>().speed = 1.5f;
        FindTarget();
    }

    private void FindTarget()
    {
        System.Random n = new System.Random();
        GameObject tmpWayPoints = GameObject.Find("Waypoint (" + n.Next(0, 8) + ")");


        if (tmpWayPoints != _target)
        {
            _target = tmpWayPoints;
        }
        else
        {
            FindTarget();
        }
    }

    private void Update()
    {
        this.GetComponent<NavMeshAgent>().destination = _target.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _target)
        {
            FindTarget();
        }
    }
}
