using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarObjeto : MonoBehaviour
{
    public GameObject ObjetoRecogible; //variable que contendra el game object del objeto que puede ser recogido
    public GameObject ObjetoRecogido; // variable que tendra el game object del objeto recogido
    public Transform interactionZone; // variable que obtendra el transform de la zona de interaccion del player (Manos)
   
    // Update is called once per frame
    void Update()
    {
        // si el objeto a recoger es distinto de nulo Y si el objeto a recoger tiene como true la variable booleana  Y si la variable del objeto regido es nula. HACER
        if (ObjetoRecogible != null && ObjetoRecogible.GetComponent<ObjetoRecogible>().isAgarrable == true && ObjetoRecogido == null)
        {
            //condicional para agarrar el objeto atravez de una tecla "F"
            if (Input.GetKeyDown(KeyCode.F))
            {
                ObjetoRecogido = ObjetoRecogible; // el objeto recogido sera igual al objeto recogible
                ObjetoRecogido.GetComponent<ObjetoRecogible>().isAgarrable = false; //la variable tipo boolean que te dice si el objeto puede ser recogido se pasa a false por que ya lo recogio.
                ObjetoRecogido.transform.SetParent(interactionZone); // se le asigna el transform al objeto padre de la zona de interaccion del player
                ObjetoRecogido.transform.position = interactionZone.position; // se le asigna la nueva posision al objeto recogido que sera igual a la de la zona de interaccion.
                ObjetoRecogido.GetComponent<Rigidbody>().useGravity = false; // se le desactiva la gravedad al objeto agarrado
                ObjetoRecogido.GetComponent<Rigidbody>().isKinematic = true; // se le activa la fisica de si es un objeto kinematico para poder moverlo.
            }
        }
        // si el objeto recogido es distinto de nulo. HAcer
        else if (ObjetoRecogido != null)
        {
            //Si la tecla "F" es precionada Hacer
            if (Input.GetKeyDown(KeyCode.F))
            {               
                ObjetoRecogido.GetComponent<ObjetoRecogible>().isAgarrable = true; //debuelve otra vez a la variable booleana su valor original para que pueda ser recogido otra vez
                ObjetoRecogido.transform.SetParent(null); // su transform del objeto padre sera nulo 
                ObjetoRecogido.GetComponent<Rigidbody>().useGravity = true; // se habilita el uso de la gravedad
                ObjetoRecogido.GetComponent<Rigidbody>().isKinematic = false; // se desabilita la opcion de is kinematic
                ObjetoRecogido = null; //la variable del objeto recogido pasara a ser nula (no contendra nada)
            }
        }
    }
}
