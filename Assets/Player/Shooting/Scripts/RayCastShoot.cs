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
    [Header("Bullet Trail")]
    [SerializeField] private Color Color;
    private LineRenderer Tracer;
    [SerializeField] private GameObject BloodBulletHole;
    [SerializeField] private GameObject BloodOnWall;
    [SerializeField] private GameObject BulletHoleOnWall;


    private Transform StartPoint;
    private AudioSource GunAudio;
    private WaitForSeconds ShotDuration = new WaitForSeconds(0);
    private float NextFire;
    public RaycastHit hit;


    void Start()
    {
        Tracer = GetComponent<LineRenderer>();
        Tracer.startColor = Color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire") && Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            Vector3 GunStart = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Tracer.SetPosition(0, GunEnd.position);
            StartCoroutine(ShootEffect());
            if (Physics.Raycast(transform.position, transform.forward, out hit, WeaponRange))
            {
                Tracer.SetPosition(1, hit.point);
                if (hit.rigidbody != null)
                {

                    if (hit.transform.GetComponent<Limb>())
                    {
                        TryDismember();
                        
                    }
                    hit.rigidbody.AddForce(-hit.normal * HitForce);
                    SetBloodBulletHole();
                    SetBloodOnWall();
                }
                //SetBulletHoleOnWall();
            }
            else
            {
                Tracer.SetPosition(1, transform.position + (transform.forward * WeaponRange));
            }
        }
    }
    private IEnumerator ShootEffect()
    {
        // Tracer.enabled = true;
        Color.a = .3f;
        while (Color.a>=0)
        {
            yield return ShotDuration;
            Color.a -= .20f*Time.deltaTime;
            Tracer.startColor = Color;

        }
       // Tracer.enabled = false;
    }

    private void TryDismember()
    {
        Limb limb = hit.transform.GetComponent<Limb>();
        limb.GetHit(GunDamage);
        limb.AddForceToBody(hit, HitForce);

    }

    private Ray GetRay()
    {
        float tx = UnityEngine.Random.Range(-0.01f,0.01f);
        float ty = UnityEngine.Random.Range(-0.01f, 0.01f);
        float tz = UnityEngine.Random.Range(-0.01f, 0.01f);

        Ray ray = new Ray(GunEnd.position, transform.forward+new Vector3(tx,ty,tz));

        return ray;
    }
    private void SetBloodBulletHole()
    {
        Transform hitTransforms = Instantiate(BloodBulletHole, hit.point - GetRay().direction * .20f, GunEnd.rotation).transform;
        hitTransforms.parent = hit.transform;
    }
    private void SetBloodOnWall()
    {
        Instantiate(BloodOnWall, hit.point - GetRay().direction * .20f, GunEnd.rotation);
    }
    ////private void SetBulletHoleOnWall()
    //{
    //    Instantiate(BulletHoleOnWall, hit.point - GetRay().direction * .70f, GunEnd.rotation);
    //}
}
