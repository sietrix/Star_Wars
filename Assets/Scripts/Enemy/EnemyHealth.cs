using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float damageBullet; // daño que hace la bala del Player

    [SerializeField]
    private Image lifeBar;

    [SerializeField]
    private ParticleSystem smallExplosion;
    [SerializeField]
    private ParticleSystem bigExplosion;



    void Awake()
    {
        smallExplosion.Stop();
        bigExplosion.Stop();
        currentHealth = maxHealth;
        lifeBar.fillAmount = 1;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            smallExplosion.Play();
            currentHealth -= damageBullet;
            lifeBar.fillAmount = currentHealth / maxHealth;
            // destruyo la bala de player (o cualquier otro gameobject
            // que esté entrando en el collider
            Destroy(other.gameObject);

            if(currentHealth <= 0)
            {
                Death();
            }

        }
    }

    private void Death()
    {
        bigExplosion.Play();
        Destroy(gameObject, 1);
    }


}
