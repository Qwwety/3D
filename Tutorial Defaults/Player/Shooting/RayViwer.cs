using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViwer : MonoBehaviour
{
    [SerializeField] private float WeaponRange;
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * WeaponRange, Color.red);
    }
}
