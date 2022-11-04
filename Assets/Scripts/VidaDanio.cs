using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaDanio : MonoBehaviour
{
    public int vida = 100;
    public bool invencible = false;
    public float timpoDeEspera = 3f;
    public float tiempoGolpe = 0.5f;
    public void RestarVida(int danio) 
    {
        if (!invencible && vida > 0)
        {
            vida -= danio;
            StartCoroutine(Invulnerabilidad());
            StartCoroutine(DetectarDanio());
            if (vida <= 0)
            {
                GameOver();
            }
        }        
    }
    void GameOver() 
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0;
    }
    IEnumerator Invulnerabilidad() 
    {
        invencible = true;
        yield return new WaitForSeconds(timpoDeEspera);
        invencible = false;
    }
    IEnumerator DetectarDanio() 
    {
        var actualSpeed = GetComponent<PlayerMov>().speed;
        GetComponent<PlayerMov>().speed = 0;
        yield return new WaitForSeconds(tiempoGolpe);
        GetComponent<PlayerMov>().speed = actualSpeed;
    }
}
