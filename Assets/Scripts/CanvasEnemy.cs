using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEnemy : MonoBehaviour
{
   
    void Update()
    {
        // mira hacia la camara de la escena que tenga la etiqueta MainCamera
        transform.LookAt(Camera.main.transform.position);
    }
}
