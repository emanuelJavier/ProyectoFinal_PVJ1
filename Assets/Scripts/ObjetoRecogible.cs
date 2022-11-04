using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoRecogible : MonoBehaviour
{
    //variable para saber si el objeto es agarrable inicializada en true
    public bool isAgarrable = true;

    //metodo de colicion para la deteccion.
    private void OnTriggerEnter(Collider other)
    {
        //si el objeto con el tag player interaccion hace contacto.
        if (other.tag == "PlayerInteraction")
        
        {
            //se obtiene su componente (script) y se le pasa el objeto 
            other.GetComponentInParent<AgarrarObjeto>().ObjetoRecogible = this.gameObject;
        }
    }

    //metodo para cuando el objeto deja de estar en contacto
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerInteraction")
        {
            //una vez que el objeto es soltado, la variable tendra un valor null
            other.GetComponentInParent<AgarrarObjeto>().ObjetoRecogible = null;
        }
    }
}
