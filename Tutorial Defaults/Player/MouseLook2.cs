using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook2 : MonoBehaviour
{
    [SerializeField] private float MouseSensitivity = 100f;
    [SerializeField] private Transform PlayerBody;
    [SerializeField] private Transform Gun;
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

        Vector3 rotPlayer = PlayerBody.transform.rotation.eulerAngles;
        Vector3 rotGun= Gun.transform.rotation.eulerAngles;

        rotGun.x -= MouseY;
        rotGun.z = 0;
        rotPlayer.y += MouseX;

        Gun.rotation = Quaternion.Euler(rotGun);
        PlayerBody.rotation = Quaternion.Euler(rotPlayer);
    }
}
