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

        // Asegúrate de que el GameObject del jugador tenga un componente Transform
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("No se encontró ningún objeto con la etiqueta 'Player'. Asegúrate de etiquetar al jugador correctamente.");
        }
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            // Mira hacia la posición del jugador
            transform.LookAt(playerTransform);
        }
    }
}
