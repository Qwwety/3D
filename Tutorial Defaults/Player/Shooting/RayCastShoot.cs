using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShoot : MonoBehaviour
{

    [SerializeField] private float GunDamage;
    [SerializeField] private float FireRate;
    public float HitForce;
    [SerializeField] private float WeaponRange;
    [SerializeField] private Transform GunEnd;

   

    private Transform StartPoint;
    private AudioSource GunAudio;
    private WaitForSeconds ShotDuration = new WaitForSeconds(0.01f);
    private LineRenderer Tracer;
    private float NextFire;
    public RaycastHit hit;


    void Start()
   {
        Tracer = GetComponent<LineRenderer>();
   }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            //StartCoroutine(ShootEffect());
            Vector3 GunStart = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            
            Tracer.SetPosition(0, GunEnd.position);

            if (Physics.Raycast(transform.position,transform.forward,out hit,WeaponRange))
            {
                Tracer.SetPosition(1, hit.point);
                if (hit.rigidbody != null)
                {
                    if (hit.transform.GetComponent<Limb>())
                    {
                        TryDismember();
                    }
                    hit.rigidbody.AddForce(-hit.normal * HitForce);
                }
            }
            else
            {
                Tracer.SetPosition(1, transform.position + (transform.forward * WeaponRange));
            }
        }
    }
    private IEnumerator ShootEffect()
    {

        Tracer.enabled = true;
        yield return ShotDuration;
        Tracer.enabled = false;
    }

    private void TryDismember()
    {
        Limb limb = hit.transform.GetComponent<Limb>();
        limb.GetHit(GunDamage);
        limb.AddForceToBody(hit, HitForce);
        Debug.Log("Try to desmember");
      
    }
}
