using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbAddForce : MonoBehaviour
{
    Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    public void AddForceTolimb(RaycastHit hit, float HitForce)
    {
        rigidbody.AddForce(-hit.normal * HitForce);
        Debug.Log("-hit.normal:"+ - hit.normal);
    }
}
