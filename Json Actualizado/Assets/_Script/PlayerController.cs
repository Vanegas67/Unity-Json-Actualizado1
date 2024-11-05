using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velMovement =5f; //Esta es una variable para velocidad de movimiento
    public float fuerzaJump = 7f; //Esta es un variable para fuerzade salto;
    


    private Rigidbody2D rb;
    private Animator animator;


    float movimientoH; //Activar el movimiento Horizontal del player (eje -x & x)
    public Transform playerTransform;

    public bool enElsuelo; //Variable par detectar el suelo

    //private Transform playerTransform; //Referencia de nuestro personaje para el Checkpoint


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //llamamos el componente RB2D
        animator = GetComponent<Animator>(); //llamos el componente Animator

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Activación de la fuerza que se le inpregna al personaje
        movimientoH = Input.GetAxis("Horizontal"); //Capturando en la varaible el input
        rb.velocity = new Vector2(movimientoH * velMovement, rb.velocity.y); //Aplicamos fuerza en el vector en los ejes
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoH)); //Aqui llamo mi animación


        //FLIP
        if (movimientoH > 0)
        {
            //mantenga el transform tal cual
            transform.localScale = new Vector3(1, 1, 1); //Movieminto hacia la derecha
        }
        if (movimientoH < 0)
        {
            //el transform debe cambiar en el eje x a - 1
            transform.localScale = new Vector3(-1, 1, 1);

        }


        //Jump
        if (Input.GetButton("Jump") && enElsuelo)
        {

            //Llamar la animación
            animator.SetBool("Jump", true);

            //Ejecución y aplicación de fuerza en Y
            rb.AddForce(new Vector2(0f, fuerzaJump), ForceMode2D.Impulse);

            //Validar el suelo
            enElsuelo = false;

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Vamos a detectar el suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElsuelo = true;
            Debug.Log("Estoy tocando el suelo");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Soy el enemigo");
           // Destroy(gameObject);
            gameObject.SetActive(false);
            PlayerDeath();
        }
        Debug.Log("El trigger funciona");
    }

    public void PlayerDeath()

    {
        RespawnCheckPoint();
    }

    public void RespawnCheckPoint()
    {
        if(CheckPoint.activateCheckPoint != null)
        {
            float playerPosX = PlayerPrefs.GetFloat("PlayerPosX");
            float playerPosY = PlayerPrefs.GetFloat("PlayerPosY");
            Vector3 respawnPosition = new Vector3(playerPosX, playerPosY, playerTransform.position.z);
            playerTransform.position = respawnPosition;
        }

        //Restaurar vida
    }


}