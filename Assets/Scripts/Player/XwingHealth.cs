using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class XwingHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth; // salud máxima
    [SerializeField]
    private float currentHealth; // salud actual
    [SerializeField]
    private float damageBullet; // daño que hace la balas enemigas

    [SerializeField]
    private Image lifeBar;
    [SerializeField]
    private ParticleSystem bigExplosion;
    [SerializeField]
    private ParticleSystem smallExplosion;

    [SerializeField]
    private GameManager gameManager;


    void Awake()
    {
        bigExplosion.Stop();
        smallExplosion.Stop();
        currentHealth = maxHealth;
        lifeBar.fillAmount = 1;
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("BulletEnemy"))
        {
            smallExplosion.Play();
            currentHealth -= damageBullet; // 100 - 10 = 90
            lifeBar.fillAmount = currentHealth / maxHealth; // 90 / 100 = 0,90
            Destroy(other.gameObject); // destruimos la bala

            if(currentHealth <= 0)
            {
                Death();
            }
        }
    }

    private void Death()
    {
        bigExplosion.Play();
        // la camara principal dejará de ser hija de la nave
        // y le dice que no tiene padre para cuando se destruya
        // no nos cargemos la camara
        Camera.main.transform.SetParent(null);
        Destroy(gameObject, 1.8f);
        gameManager.GameOver();
    }





}
