using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoles : MonoBehaviour
{
    [Header("Bullet Holes")]
    [SerializeField] private GameObject[] BulletHole;

   public void SetBulletHole(RaycastHit hit)
    {
        int HoleIndex = 0;
        switch (hit.transform.gameObject.layer)
        {
            case 11:
                HoleIndex = 0;
                break;
            case 12:
                HoleIndex = 1;
                break;
        }
        Instantiate(BulletHole[HoleIndex], hit.point+new Vector3(0f,0f,-0.02f), Quaternion.LookRotation(-hit.normal));
   }
}
