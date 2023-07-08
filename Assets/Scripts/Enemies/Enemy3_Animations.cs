using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Para poder usar la paqueteria de A* Pathfinder
using Pathfinding;

public class Enemy3_Animations : MonoBehaviour
{

    //Animator nos permitira indicar las animaciones que debemos de realizar
    public Animator animator;
    //Parte de la paqueteria de A*
    public AIPath aiPath;
    //Agregamos un efecto de sonido para indicar al jugador el daño recibido
    [SerializeField] AudioClip damageSfx;
    //Una variable para indicar el daño que se realizara al jugador
    [SerializeField] int damage = -30;
    //Para dañar al jugador
    [SerializeField] int notScore = -1;

    // Update is called once per frame
    void Update()
    {
        //Revisamos la dirección en la que se esta moviendo de acuerdo a su velocidad
        if(aiPath.desiredVelocity.x >= 0.1f)
        {
            animator.SetFloat("Horizontal", -1);
            animator.SetFloat("Vertical", 0);
        }else if(aiPath.desiredVelocity.x <= -0.01)
        {
            animator.SetFloat("Horizontal", 1);
            animator.SetFloat("Vertical", 0);
        }
        
    }

    //Reducir la vida del jugador cuando entre en contacto con el enemigo
    void OnTriggerEnter2D(Collider2D other)
    {
        //Comparamaos si entraron en contacto
        if (other.gameObject.CompareTag("Player"))
        {
            //Hacemos que suene el sonido de daño
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(damageSfx);
            //Modiicamos la salud del jugador
            PlayerHealth.instance.ModifyHP(damage);
            //Modificamos el puntaje del jugador
            LevelManager.instance.IncreaseScore(notScore, 0); //Solo modificaremos el puntaje (primer parametro)
        }
    }

}
