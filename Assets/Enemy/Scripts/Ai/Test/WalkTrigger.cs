using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTrigger : MonoBehaviour
{
    [SerializeField] private EnemyAI EnemyAI;

    private void OnTriggerEnter(Collider other)
    {
        EnemyAI.GoToCover();
    }
}
