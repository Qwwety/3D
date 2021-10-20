using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public static EnemyAI Instance;
    private Animator Animator;

    [Header("Movement")]
    public Transform TargetPosition;
    [Header("Shooting")]
    public Transform Enemy;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform GunEnd;
    [SerializeField] private int AmmoCount;
    [SerializeField] private float Inaccuracy;
    private Ray ray;
    private Vector3 vector;
    [Header("Anim Controll")]
    [SerializeField] public Transform AfterAnimPos;
    [Header("NavMesh")]
    public NavMeshAgent NavMeshAgent;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Animator = GetComponent<Animator>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
        vector = GunEnd.position;
    }

    public void AttackPlayer()
    {
        LookAtPlayer();
        vector += Random.insideUnitSphere * Inaccuracy;
        Instantiate(Bullet, GunEnd.forward + vector, GunEnd.rotation);
        vector = GunEnd.position;
        AmmoCount -= 1;
        Animator.SetInteger("Ammo", AmmoCount);
    }
    public void Reload()
    {
        AmmoCount = 30;
        Animator.SetTrigger("Shoot");
    }
    public void GoToCover()
    {
        this.GetComponent<Rigidbody>().isKinematic = false;
        NavMeshAgent.SetDestination(TargetPosition.position);
    }
    public void StayCalm()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;
    }
    public void LookAtPlayer()
    {
        Vector3 vector = new Vector3(Enemy.transform.position.x, transform.position.y, Enemy.transform.position.z);
        transform.LookAt(vector);
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100);
    }
    public void SetPositionToAnim()
    {
        this.transform.position = AfterAnimPos.transform.position;
        Debug.Log("TT");
    }
    public void StartShoot()
    {
        Animator.SetTrigger("Shoot");
    }
    public void FollowEnemy()
    {
        NavMeshAgent.SetDestination(Enemy.transform.position);
    }
    public void StopFollow()
    {
        NavMeshAgent.isStopped = true;
    }
}
