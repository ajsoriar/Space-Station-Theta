using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveEnemiga : MonoBehaviour
{
    public Transform jugador;

    [Range (0f, 360f)]
    public float campoVision;

    [Range(1f, 5f)]
    public float longitudGuias;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        //Debug.DrawRay(transform.position, transform.up * longitudGuias, Color.green);

        Vector3 limiteIzquierdo = Quaternion.Euler(Vector3.forward * -campoVision * 0.5f) * transform.up;
        Debug.DrawRay(transform.position, limiteIzquierdo * longitudGuias, Color.red);

        Vector3 limiteDerecho = Quaternion.Euler(Vector3.forward * campoVision * 0.5f) * transform.up;
        Debug.DrawRay(transform.position, limiteDerecho * longitudGuias, Color.red);

        // Direccion de la nave enemiga al jugador

        Vector3 direccion_a_player = jugador.position - transform.position;
        float gradosHastaJugador = Vector3.Angle(transform.up, direccion_a_player);

        if (gradosHastaJugador < campoVision * 0.5f)
        {
            Debug.Log("Jugador esta DENTRO DEL CAMPO DE VISION");
            Debug.DrawRay(transform.position, direccion_a_player, Color.red);
        }
        else
        {
            Debug.Log("Jugador esta FUERA DEL CAMPO DE VISION");
            Debug.DrawRay(transform.position, direccion_a_player, Color.yellow);

        }
    }
}
