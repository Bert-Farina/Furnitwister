using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb2D;
    public float maxSpeed, moveSpeed, initialMoveSpeed;
    Vector2 movement;
    
    //Variables para control de tiempo de salto
    private float startTime;
    private float jumpTime = 0.7f;
    private float jumpSpeed, fallSpeed;
    public bool isInTheAir;

    private void Start() 
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        initialMoveSpeed = 10.0f;
        moveSpeed = initialMoveSpeed;
        maxSpeed = 50.0f;
        jumpSpeed = 7.5f;
        fallSpeed = -7.5f;
    }

    private void Update() 
    {
        //Movimiento según las teclas WASD
        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1.0f;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.D))
            {
                movement.x = 1.0f;
            }
            else
            {
                movement.x = 0.0f;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement.x = 1.0f;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                movement.x = -1.0f;
            }
            else
            {
                movement.x = 0.0f;
            }
        }

        //Comprobar en que dirección se mueve para hacer un flip del sprite
        if(movement.x > 0 && transform.localScale.x != 0.5f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (movement.x < 0 && transform.localScale.x != -0.5f)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }

        //Activar o desactivar la animación de caminar
        if(movement.x != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        //Control del salto
        if(Input.GetKeyDown(KeyCode.Space) && !isInTheAir)
        {
            movement.y = jumpSpeed;
            startTime = Time.time;
            anim.SetBool("isJumping", true);
            isInTheAir = true;
        }
        else if(Input.GetKeyUp(KeyCode.Space) || (Time.time - startTime) > jumpTime)
        {
            movement.y = fallSpeed;
        }
    
        //Control de reducirse
        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.S))
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.S))
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        //Se multiplica la dirección en X por el movimiento en cada momento
        movement.x *= moveSpeed;
    }

    private void FixedUpdate() 
    {
        //Si la velocidad es la normal se mueve de manera normal
        if(moveSpeed <= initialMoveSpeed)
        {
            rb2D.MovePosition(rb2D.position + movement * Time.fixedDeltaTime);
        }
        //Si la velocidad es mayor que la normal, pero menor o igual que la velocidad máxima se irá reduciendo su velocidad con un factor de 0.9
        else if(moveSpeed > initialMoveSpeed && moveSpeed <= maxSpeed)
        {
            moveSpeed = 0.9f * moveSpeed;
            rb2D.MovePosition(rb2D.position + movement * Time.fixedDeltaTime);
        }
    }
}
