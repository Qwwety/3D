using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{
    public Enemy Enemy;
    Rigidbody rigidbody;
    [SerializeField] Limb[] childLimbs;
    [SerializeField] GameObject LimbPrefab;
    [SerializeField] GameObject woundHole;
    [SerializeField] GameObject bloodPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Enemy = transform.root.GetComponent<Enemy>();
        if (woundHole!=null)
        {
            woundHole.SetActive(false);
        }
    }

    public void GetHit(float Damage)
    {
        Enemy.TakeDamage(Damage);
        Debug.Log("Take Damege");
        if (LimbPrefab!=null && Damage>=Enemy.GetCurentHealth()) 
        {
            if (childLimbs.Length > 0)
            {
                foreach (Limb limb in childLimbs)
                {
                    if (limb != null)
                    {
                        limb.GetHit(Damage);
                    }
                }
            }

            if (woundHole != null)
            {
                woundHole.SetActive(true);
                if (bloodPrefab != null)
                {
                    Instantiate(bloodPrefab, woundHole.transform.position, woundHole.transform.rotation);
                }
            }
            if (LimbPrefab != null)
            {
                Instantiate(LimbPrefab, transform.position, transform.rotation);
            }
            transform.localScale = Vector3.zero;
            Destroy(this);
        }
    }
    public void AddForceToBody(RaycastHit hit, float HitForce)
    {
        this.rigidbody.AddForce(-hit.normal*HitForce); 
    }

}
