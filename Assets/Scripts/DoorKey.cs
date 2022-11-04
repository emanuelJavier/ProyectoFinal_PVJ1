using UnityEngine;
using System.Collections;

public class DoorKey : MonoBehaviour
{

    public bool isTrigger;

    void OnTriggerEnter(Collider other)
    {
        isTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        isTrigger = false;
    }

    void Update()
    {
        if (isTrigger) //si es un trigger y si luego se preciona "E"
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DoorScript.key = true;
                Destroy(this.gameObject);
            }
        }
    }

    void OnGUI()
    {
        if (isTrigger)
        {
            GUI.Box(new Rect(0, 60, 200, 25), "Press E to take key"); //se crea un mensaje en una parte determinada
        }
    }
}