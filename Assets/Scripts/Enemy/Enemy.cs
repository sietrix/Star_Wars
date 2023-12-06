using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private int speed;
    [SerializeField ]
    private float distanceToPlayer;

    [Header("Attack")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform[] posRotBullet;
    [SerializeField]
    float timeBetweensBullets;

    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Attack", 1, timeBetweensBullets);
    }

    void Update()
    {
        // si no existe el player salte de la función
        if(player == null) return;

        // El LookAt hace que mire a esa posición dada por parametro
        transform.LookAt(player.transform.position);

        FollowPlayer();
    }

    void FollowPlayer()
    {
        // Calculo la distancia que hay entre el enemigo y el player en metros
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance > distanceToPlayer)
        {
            // Movemos a la nave enemiga con el método Translate, indicandele:
            // el eje en el que la voy a mover y a que velocidad transformada a metros por segundo
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
    }

    void Attack()
    {
        for(int i = 0; i < posRotBullet.Length; i++)
        {
            Instantiate(bulletPrefab, posRotBullet[i].position, posRotBullet[i].rotation);
        }
    }



}
