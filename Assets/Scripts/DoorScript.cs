using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{

    public static bool key;
    public bool open;
    public bool close;
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
        if (isTrigger)
        {
            if (close)
            {
                if (key)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        open = true;
                        close = false;
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    close = true;
                    open = false;
                }
            }
        }

        if (open)
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
        }
        else
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
        }
    }

    void OnGUI()
    {
        if (isTrigger)
        {
            if (open)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Presiona la tecla E para cerrar");
            }
            else
            {
                if (key)
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "Presiona la tecla E para abrir");
                }
                else
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "¡Necesitas una llave!");
                }
            }
        }
    }
}