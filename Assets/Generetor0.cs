using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generetor0 : MonoBehaviour
{
    [SerializeField] GameObject pelota; //vatiable de tipo game object
    [SerializeField] private float initTime; // tiempo inicial
    [SerializeField] private float repeatTime; // itmepo de repeticionin
    private int contador = 0;
    
    void Start()
    {
       //metodo invoke repeating donde se le pasa el metodo , tiempo inicial, y tiempo de repeticion
        InvokeRepeating("CreatePelota",initTime,repeatTime);
    }
    // metodo que se encargara de instanciar un objeto de tipo pelota
    void CreatePelota()
    {
        if (contador < 3) 
        {
            Instantiate(pelota, transform.position, transform.rotation);
            contador += 1;
        }
        
    }
}
