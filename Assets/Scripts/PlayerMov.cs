using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMov : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f;

    public float gravity = -12f;

    public float jumpHeight = 0.02f;

    public Transform groundCheck;

    public float gruoundDistance = 0.3f;

    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    public AudioSource pasos;

    public AudioSource latidos;

    private bool Hactivo;

    private bool Vactivo;

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,gruoundDistance,groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move* speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        if (Input.GetMouseButtonDown(0))
        {
            this.speed -= 4;
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            this.speed += 4;
        }

        if (Input.GetMouseButtonDown(1))
        {
            this.speed += 2;
            
        }

        if (Input.GetMouseButtonUp(1))
        {
            this.speed -= 2;
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            Hactivo = true;
            pasos.Play();
         
            latidos.Play();
        }

        if (Input.GetButtonDown("Vertical"))
        {
            Vactivo = true;
            pasos.Play();
          
            latidos.Play();
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            Hactivo = false;
            if (Vactivo == false)
            {
                pasos.Pause();
               

            }

        }

        if (Input.GetButtonUp("Vertical"))
        {
            Vactivo = false;
            if (Hactivo == false)
            {
                pasos.Pause();
                
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity* Time.deltaTime);
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", z);
    }
}
