using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorConttrol : MonoBehaviour
{
    [SerializeField] private Transform Door;
    private void OnTriggerEnter(Collider other)
    {
        Door.transform.position = new Vector3(Door.transform.position.x, Door.transform.position.y, Door.transform.position.z + 4.3f);
    }
    private void OnTriggerExit(Collider other)
    {

        //Door.transform.position = new Vector3(Door.transform.position.x, Door.transform.position.y, Door.transform.position.z -6f);

    }
}
