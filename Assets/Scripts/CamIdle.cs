using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamIdle : MonoBehaviour
{
  
    [SerializeField]
    private float speedY = -1f;

  
   
    public void Update()
    {

        if (transform.position.y < 2.5f || transform.position.y > 1.30f)
        {
            speedY *= -1;
        }
        transform.Translate(0, speedY * Time.deltaTime, 0);

    }
}

