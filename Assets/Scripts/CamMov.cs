using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CamMov : MonoBehaviour
{
    public float sensibilidadMouse = 130;
    public Transform playerBody;
    float xRotacion = 0;
    void Start()
    {
        
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;

        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;

        xRotacion -= mouseY;

        xRotacion = Mathf.Clamp(xRotacion, -80f, 65f);

        transform.localRotation = Quaternion.Euler(xRotacion, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

    }

   
    
}
