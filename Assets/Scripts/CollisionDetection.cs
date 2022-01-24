using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    int lifes, maxLifes = 5;
    public BoxCollider2D topCollider;
    public CompositeCollider2D floorCollider;
    private Animator anim;
    private PlayerControl playerControl;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        lifes = maxLifes;
        healthBar.SetMaxHealth(maxLifes);
        floorCollider = GameObject.Find("Terrain").GetComponent<CompositeCollider2D>();
        anim = GetComponent<Animator>();
        playerControl = GetComponent<PlayerControl>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Si colisiona con una silla o mesa con la que no haya colisionado antes y con su box collider superior
        if ((other.gameObject.name == "Silla(Clone)" || other.gameObject.name == "Table(Clone)") && !other.gameObject.GetComponent<ObstacleMovement>().hasCollided
            && other.otherCollider == topCollider)
        {
            //Se reduce la vida en uno y también en la barra de vida del HUD
            lifes--;
            healthBar.SetHealth(lifes);

            //Si la vida es cero se activa la animación de muerte, y si no, la animación de herida
            if(lifes <= 0)
            {
                anim.SetBool("isDead", true);
            }
            else
            {
                other.gameObject.GetComponent<ObstacleMovement>().hasCollided = true;
                anim.SetBool("isHurt", true);
            }
        }

        // Si colisiona con el suelo se detiene la animación de salto y se le informa al control del jugador que ya no está en el aire
        if (other.collider.GetType() == floorCollider.GetType())
        {
            anim.SetBool("isJumping", false);
            playerControl.isInTheAir = false;
        }
    }

    // Triggers para los turbos y la puerta de final de nivel
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Turbos")
        {
            this.GetComponent<PlayerControl>().moveSpeed = this.GetComponent<PlayerControl>().maxSpeed;
        }
        else if(other.gameObject.name == "ExitDoor")
        {
            FindObjectOfType<GameManager>().WinGame();
        }
    }
}
