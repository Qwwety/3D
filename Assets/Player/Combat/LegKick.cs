using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegKick : MonoBehaviour
{
    private Collider[] EnemyRB;
    private Rigidbody PlayerRB;
    private RaycastHit hit;
    [SerializeField] private float KickForce;
    [SerializeField] private Transform LegPoint;
    [SerializeField] private float LegRange;
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && Physics.Raycast(transform.position, transform.forward, out hit, LegRange))
        {
            if (hit.rigidbody!=null)
            {
                if (hit.transform.GetComponent<Limb>())
                {
                    Kick();
                }
                hit.rigidbody.AddForce(-hit.normal * KickForce);
            }
        }
    }

    private void Kick()
    {
        Limb limb = hit.transform.GetComponent<Limb>();
        //limb.Enemy.GetKilled();
    }
}
