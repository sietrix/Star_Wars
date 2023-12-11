using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform[] posRotEnemy;
    [SerializeField]
    private float timeBetweenEnemies;


    void Start()
    {
        InvokeRepeating("CreateEnemies", timeBetweenEnemies, timeBetweenEnemies);
    }

    private void CreateEnemies()
    {
        // se genera numero aleatorio para el indice del array
        int n = Random.Range(0, posRotEnemy.Length);

        Instantiate(enemyPrefab, posRotEnemy[n].position, posRotEnemy[n].rotation);
    }
   
}
