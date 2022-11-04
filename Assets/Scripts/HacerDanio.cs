using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HacerDanio : MonoBehaviour
{
    public int danio = 30;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            other.GetComponent<VidaDanio>().RestarVida(danio);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<VidaDanio>().RestarVida(danio);
        }
    }
}
