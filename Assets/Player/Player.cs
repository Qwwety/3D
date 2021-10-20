using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;


    [Header("Health")]
    [SerializeField] private float MaxHealth;
    [SerializeField] private float CurrentHealth;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void GetDamage(float Damage)
    {
        CurrentHealth -= Damage;
        if (CurrentHealth<=0)
        {
            Debug.Log("Dead");
        }
    }
}
