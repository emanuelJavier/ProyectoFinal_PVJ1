using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorGenerador : MonoBehaviour
{
    public Rigidbody platformRB; 
    public Transform[] platformPositions; //array de los puntos donde se pósicionara la plataforma cadavez que se mueva.
    public float platformSpeed;

    private int actualPosition = 0;
    private int nextPosition = 1;

    public bool moveToTheNext = true; //si mover al siguiente es cierto.
    public float waitTime; //tiempo de espera

    // Update is called once per frame
    void Update()
    {
        MoverGenerador();
    }
    private void MoverGenerador()
    {
        //si mover al siguiente punto de desplazamiento es verdadero
        if (moveToTheNext) 
        {
            StopCoroutine(waitForMove(0));//para la corrutina mientras se mueve
            //su componente Rigibody se movera a la posicion del siguiente punto de encuentro o de espera
            platformRB.MovePosition(Vector3.MoveTowards(platformRB.position, platformPositions[nextPosition].position, platformSpeed * Time.deltaTime));
        }
        //si la distancia entre la posicion actual y la siguiente es <= que "0".
        if (Vector3.Distance(platformRB.position, platformPositions[nextPosition].position) <= 0)
        {
            StartCoroutine(waitForMove(waitTime));//inicializar la corrutina
            actualPosition = nextPosition;
            nextPosition++;
            //Notacion..!!
              /* esta ultima accion conducira a un error de que cuando de supere el limite del array el objeto no regrece a su posicion Original. Para esto lo siguiente*/


            if (nextPosition > platformPositions.Length - 1)
            {
                nextPosition = 0;
            }
        }
    }
    // una corrutina es un metodo que se ejecuta en segundo planosin afectar el codigo.
    // siempre que se crea una corrutina tiene que devolver algo por eso yield return (y el valor que devuelve)
    //waitForMove es un metodo ya de unity
    IEnumerator waitForMove(float time) 
    {
        moveToTheNext = false;
        //yield return se usa para devolver un valor de cualquier tipo
        yield return new WaitForSeconds(time); // wait for seconds es una funciond e unity para saber el tiempo de ejecusiond e algun objeto
        moveToTheNext = true;
    }
}
