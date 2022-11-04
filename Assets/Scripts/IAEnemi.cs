using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAEnemi : MonoBehaviour
{
    //variables para indicar, rutina, un cronometro, la animacion, una rotacion, y los grados.
    public int rutina;
    public float cronometro;
    public Animator animacion;
    public Quaternion anguloRotacion;
    public float grado;
    //objetivo
    public GameObject objetivo;
    public GameObject puerta;
    //ataque
    public bool atacando;
    //Nav-Mesh

    public NavMeshAgent IA;
    public GameObject enemi;
    [SerializeField] private float speed;

    //Sonidos
    //public AudioSource pasos;
    //public AudioSource respiracion;
    //private bool Hactivo;
    //private bool Vactivo;
    
    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
        objetivo = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
       // respiracion.Play();
        //pasos.Play();
        ComportamientoEnemi();
        IA.speed = speed;

    }
    public void ComportamientoEnemi()
    {
        
        if (Vector3.Distance(transform.position, objetivo.transform.position) > 5)
        {
            animacion.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    animacion.SetBool("walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    anguloRotacion = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, anguloRotacion, 0.5f);
                    //IA.SetDestination(objetivo.transform.position);
                    
                    transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                    animacion.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            /*if (Vector3.Distance(transform.position, objetivo.transform.position) > 2 && !atacando)
            {*/
            var mirarPlayer = objetivo.transform.position - transform.position;
            mirarPlayer.y = 0;
            var rotacion = Quaternion.LookRotation(mirarPlayer);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 2);
            animacion.SetBool("walk", false);
            animacion.SetBool("run", true);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
            //IA.SetDestination(objetivo.transform.position);
            animacion.SetBool("attack", false);
            /*}
            else 
            {
                animacion.SetBool("walk", false);
                animacion.SetBool("run", false);
                animacion.SetBool("attack", true);
                atacando = true;
            }*/
        }
    }
    /* public void TerminarAnimacion() 
     {
         animacion.SetBool("attack", false);
         atacando = false;
     }*/
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coliciona");
        if (other.CompareTag("Puerta"))
        {
            puerta.GetComponent<Interactuar>().AbrirCerrarPuerta();
            Debug.Log("esta entrando a su script");
        }
    }
}