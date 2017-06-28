using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PNJPathfinding : MonoBehaviour {
    
    public GameObject _target;

    private void Start()
    {
        this.gameObject.AddComponent<NavMeshAgent>();
        this.gameObject.GetComponent<NavMeshAgent>().radius = 1;
        this.gameObject.GetComponent<NavMeshAgent>().height = 3.5f;
    }

    private void Update()
    {
        this.GetComponent<NavMeshAgent>().destination = _target.transform.position;
    }
}
