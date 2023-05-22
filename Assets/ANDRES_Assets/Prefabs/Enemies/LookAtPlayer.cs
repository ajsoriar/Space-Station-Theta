using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform playerTransform;

    private void Start()
    {
        // Encuentra el GameObject con la etiqueta "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // Aseg�rate de que el GameObject del jugador tenga un componente Transform
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("No se encontr� ning�n objeto con la etiqueta 'Player'. Aseg�rate de etiquetar al jugador correctamente.");
        }
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            // Mira hacia la posici�n del jugador
            transform.LookAt(playerTransform);
        }
    }
}
