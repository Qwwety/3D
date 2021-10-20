using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private float WeaponRange;
    [SerializeField] private int AmmoCount;
    [SerializeField] private bool IsReloading=false;
    [SerializeField] private Transform PlayerTransform;
    private NavMeshAgent NavMeshAgent;
    private Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        LookAtPlayer();
        AttackPlayer();
    }
    private void AttackPlayer()
    {
        if (AmmoCount<=0 && IsReloading==false)
        {
            StartCoroutine(Reload());
        }
        else if(AmmoCount > 0)
        {
            Debug.Log("I shooting to player");
            AmmoCount -= 1;
        }
    }
    IEnumerator Reload()
    {
        IsReloading = true;
        yield return new WaitForSeconds(5);
        Debug.Log("I am Reloaded");
        AmmoCount = 100;
        IsReloading = false;
    }
    private void LookAtPlayer()
    {
        Vector3 vector = new Vector3(PlayerTransform.transform.position.x, transform.position.y, PlayerTransform.transform.position.z);
        transform.LookAt(vector);
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100);
    }
}
