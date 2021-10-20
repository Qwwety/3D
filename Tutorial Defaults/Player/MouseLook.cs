using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float MouseSensitivity = 100f;
    [SerializeField] private float AngleZ;
    [SerializeField] private Transform PlayerBody;
    //[SerializeField] private Transform Gun;
    [SerializeField] private PlayerMovmentByRB PlayerMovmentByRB;
    private float XRrotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;


        XRrotation -= MouseY;
        XRrotation = Mathf.Clamp(XRrotation, -90f, 90f);



        if (PlayerMovmentByRB.HorizontalMovment >0)
        {
            transform.localRotation = Quaternion.Euler(XRrotation, 0f, -AngleZ);
        }
        else if (PlayerMovmentByRB.HorizontalMovment < 0)
        {
            transform.localRotation = Quaternion.Euler(XRrotation, 0f, AngleZ);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(XRrotation, 0f, 0f*Time.deltaTime);
        }
        PlayerBody.Rotate(Vector3.up * MouseX);
        
    }
}
