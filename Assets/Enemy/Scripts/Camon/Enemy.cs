using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;
    [Header("Hp")]
    [SerializeField] private float CurrentHealth;
    [SerializeField] private float StartingHealth = 100;


    private Animator Animator;
    private List<Rigidbody> ragdollRigids;
    private NavMeshAgent NavMeshAgent;
    private EnemyAI EnemyAI;


    void Start()
    {
        CurrentHealth = StartingHealth;
        Animator = GetComponent<Animator>();
        ragdollRigids = new List<Rigidbody>(transform.GetComponentsInChildren<Rigidbody>());
        ragdollRigids.Remove(GetComponent<Rigidbody>());
        NavMeshAgent = GetComponent<NavMeshAgent>();
        EnemyAI = GetComponent<EnemyAI>();
        DeactivateRagdoll();
    }
    private void ActivateRagdoll()
    {
        Animator.enabled = false;
        NavMeshAgent.enabled = false;
        EnemyAI.enabled = false;
        for (int i = 0; i < ragdollRigids.Count; i++)
        {
            ragdollRigids[i].useGravity = true;
            ragdollRigids[i].isKinematic = false;
        }
    }
    private void DeactivateRagdoll()
    {
        Animator.enabled = true;
        NavMeshAgent.enabled = true;
        EnemyAI.enabled = true;
        for (int i = 0; i < ragdollRigids.Count; i++)
        {
            ragdollRigids[i].useGravity = false;
            ragdollRigids[i].isKinematic = true;
        }
    }

    public float GetCurentHealth()
    {
        return CurrentHealth;
    }

    public void TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;
        if (CurrentHealth <= 0)
        {
            GetKilled();
        }
    }

    private void GetKilled()
    {
        ActivateRagdoll();
    }

}
