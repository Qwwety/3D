using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShooting : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemys;
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < Enemys.Length; i++)
        {
            Enemys[i].GetComponent<Animator>().SetTrigger("Shoot");
            Debug.Log("fd");
        }
    }
}
