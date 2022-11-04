using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuar : MonoBehaviour
{
    //luz
    public GameObject LuzObjeto;
    public bool Luz;
    public bool luzOnOff;
    //Puerta
    public GameObject puertaObjeto;
    public bool puerta;
    public bool abrirCerrar;
    public float abrir = 90f;
    //private float cerrar = 0.0f;
    //private float speed = 1f; //velocidad de rotacion de la puerta

    public void OnOffLuz()
    {
        luzOnOff = !luzOnOff;

        if (luzOnOff == true)
        {
            LuzObjeto.SetActive(true);
        }

        if (luzOnOff == false)
        {
            LuzObjeto.SetActive(false);
        }
    }
    public void AbrirCerrarPuerta()
    {

        abrirCerrar = !abrirCerrar;
        if (abrirCerrar == true)
        {
            //Quaternion targetRotation = Quaternion.Euler(0, abrir, 0);
            //puertaObjeto.transform.parent.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, speed * Time.deltaTime);
            puertaObjeto.transform.parent.Rotate(0, abrir, 0);
        }
        if (abrirCerrar == false)
        {
            //Quaternion targetRotation2 = Quaternion.Euler(0, cerrar , 0);
            //puertaObjeto.transform.parent.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, speed * Time.deltaTime);
            puertaObjeto.transform.parent.Rotate(0, abrir * -1, 0);
        }
    }
}