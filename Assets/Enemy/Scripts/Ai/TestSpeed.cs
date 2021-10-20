using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpeed : MonoBehaviour
{
    Rigidbody PlayerRB;
    [SerializeField] private float Speed;
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Speed = PlayerRB.velocity.magnitude;
    }
}
