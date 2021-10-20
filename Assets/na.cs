using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class na : MonoBehaviour
{
    [SerializeField] public Transform TT;
    public NavMeshAgent NavMeshAgent;
    void Start()
    {
        NavMeshAgent.SetDestination(TT.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent.SetDestination(TT.transform.position);
    }
}
