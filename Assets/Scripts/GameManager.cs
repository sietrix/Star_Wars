using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panelGameOver;
    [SerializeField]
    private EnemyManager enemyManager;


    // estre método es el que llamaremos al pulsa el botón Retry
    public void LoadSceneLevel()
    {
        SceneManager.LoadScene("Level01");
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);
        enemyManager.enabled = false;  // para desactivar el componente EnemyManager
        Cursor.lockState = CursorLockMode.Confined; // desbloquear el cursor
    }



}
