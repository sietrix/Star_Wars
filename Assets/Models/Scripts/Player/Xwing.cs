using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xwing : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private int speed;
    [SerializeField]
    private int turnSpeed;

    void Awake()
    {
        
    }

    void Update()
    {
        Movement();
        Turning();
    }

    // Para mover mi nave espacial en el eje X y Z
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Teclas A y D
        float vertical = Input.GetAxis("Vertical"); // Teclas W y D
        // se le asigna los ejes (X, Y, Z)
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    // Movemos nuestra nave en el eje Y, para girarla
    void Turning()
    {
        float xMouse = Input.GetAxis("Mouse X"); // Recoger el desplazamiento horizontal del rat�n
        float yMouse = Input.GetAxis("Mouse Y"); // Recoger el desplazamiento vertical del rat�n
        Vector3 rotation = new Vector3(-yMouse, xMouse, 0);
        transform.Rotate(rotation.normalized * turnSpeed * Time.deltaTime); // se normaliza el vector para que se mueva a la misma velocidad en todas las direcciones 
    }


}
