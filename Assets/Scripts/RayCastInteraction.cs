using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastInteraction : MonoBehaviour
{
    public int rango;
    public LayerMask mask;

    //interfaz del Canvas
    //public Texture2D puntero;
    public GameObject TextDetect;
    GameObject ultimoReconocido = null;

    private void Start()
    {
        mask = LayerMask.GetMask("RayCastDetect");
        TextDetect.SetActive(false);
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rango, mask))
        {
            Deselect();
            SelectObject(hit.transform); //se obtiene la info del game Object con el cual impactamos

            if (hit.collider.GetComponent<Interactuar>())
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.collider.GetComponent<Interactuar>().Luz == true)
                    {
                        hit.collider.GetComponent<Interactuar>().OnOffLuz();
                    }
                    if (hit.collider.GetComponent<Interactuar>().puerta == true)
                    {
                        hit.collider.GetComponent<Interactuar>().AbrirCerrarPuerta();
                    }
                }
            }
        } else {Deselect();}
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * rango);
    }

    void SelectObject(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        ultimoReconocido = transform.gameObject;
    }
    void Deselect() 
    {
        if (ultimoReconocido) 
        {
            ultimoReconocido.GetComponent<Renderer>().material.color = Color.white;
            ultimoReconocido = null;
        }
    }
     void OnGUI()
    {
        //Rect rect = new Rect(Screen.width / 2 , Screen.height / 2 , puntero.width, puntero.height);
        //GUI.DrawTexture(rect, puntero);
        if (ultimoReconocido)
        {
            TextDetect.SetActive(true);
        }
        else
        {
            TextDetect.SetActive(false);
        }
    }
}
