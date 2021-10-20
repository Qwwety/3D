using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletConttrol : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float Damage;

    private void Start()
    {
        Destroy(gameObject,5);
    }
    void FixedUpdate()
    {
        transform.position += transform.forward*Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Player.Instance.GetDamage(Damage);
        }
        Destroy(gameObject);
    }
    //private void OnCollisionStay(Collision collision)
    //{
    //    Destroy(gameObject,4);
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    Destroy(gameObject);
    //}
}
