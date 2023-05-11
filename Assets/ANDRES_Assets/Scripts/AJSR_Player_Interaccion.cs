using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AJSR_Player_Interaccion : MonoBehaviour
{
    public Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)){ // Boton izquierdo
            Ray ray = new Ray(cam.position, cam.forward);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 5f)){ // 1f, es la longitud del rayo invisible
                Debug.Log("El raycast detecta un objeto: "+ hit.collider.gameObject.name);

                if (hit.collider.CompareTag("Interruptores")){
                    Debug.Log("!!!!! El raycast detecta un interruptor !!!!!");

                    Transform interruptorDetectado = hit.collider.transform;

                    interruptorDetectado.parent.GetChild(0).gameObject.SetActive(false);
                }

            }else{
                Debug.Log("El raycast NO detecta objetos");
            }
        }
    }
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaccion : MonoBehaviour
{
    private Transform cam;

    public int contadorMonedas;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // ¿Hago click izquierdo con el raton?
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(cam.position, cam.forward); // define un rayo invisible segun un origen y direccion
            RaycastHit hit; // extiende la informacion de un rayo invisible

            // Si el rayo invisible o Raycast detecta algo...
            if (Physics.Raycast(ray, out hit, 5f))
            {
                // Si ese algo que ha detectado tiene asignada la etiqueta "Interruptores"...
                if (hit.collider.CompareTag ("Interruptores"))
                {
                    // almaceno temporalmente el componente "Transform" del interruptor en la variable "interruptorDetectado"
                    Transform interruptorDetectado = hit.collider.transform;

                    // usando la variable "interruptorDetectado" navego por código a su padre y a su vez a su primer hijo
                    // a continuacion accedo con ese primer hijo, a su clase GameObject para utilizar la funcion "SetActive (false)"

                    bool estadoActualPuerta = interruptorDetectado.parent.GetChild(0).gameObject.activeSelf;
                    interruptorDetectado.parent.GetChild(0).gameObject.SetActive(!estadoActualPuerta);

                    Debug.Log("El raycast detecta un interruptor");
                }

                if (hit.collider.CompareTag("Monedas"))
                {
                    // desactiva el objeto que ha sido capaz de detectar el rayo invisible...
                    hit.collider.gameObject.SetActive(false);

                    contadorMonedas++; // suma una unidad al valor previo almacenado
                }


                if (hit.collider.CompareTag(("PonerNombreDeEtiquetaAqui..."))){

                }
            }

            // Si el rayo invisible o Raycast no detecta nada...
            else
            {
                Debug.Log("El raycast no ha detectado nada");
            }
        }
    }
}

*/
