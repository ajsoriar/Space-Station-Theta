using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AJSR_Object_Interaccion : MonoBehaviour
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
                if (hit.collider.CompareTag("Interruptores"))
                {
                    Debug.Log("!!!!! El raycast detecta un interruptor !!!!!");
                    Transform interruptorDetectado = hit.collider.transform;
                    //hit.collider.gameObject.SendMessage("realizaAccion", 1); // gameObject.SendMessage("realizaAccion", 1);
                }
            }else{
                //Debug.Log("El raycast NO detecta objetos");
            }
        }
    }
}
