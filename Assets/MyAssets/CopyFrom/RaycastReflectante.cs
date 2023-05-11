using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastReflectante : MonoBehaviour
{
    public Transform rayOrigen;
    public float rayLongitud;

    public Transform objetoSeleccionado;

    public float velocidadRotacion;

    LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // ¿Se presiona el boton izquierdo del raton..?
        if (Input.GetMouseButtonDown(0))
        {
            RaycastSeleccionObjeto();
        }

        if (objetoSeleccionado != null)
        {
            float inputHorizontal = Input.GetAxisRaw("Horizontal");
            objetoSeleccionado.Rotate(new Vector3(0f, inputHorizontal, 0f) * velocidadRotacion * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        RaycastFrontal();
    }

    void RaycastFrontal()
    {
        Ray ray = new Ray(rayOrigen.position, rayOrigen.forward);
        RaycastHit hit;

        // se establece el punto de origen del line renderer almacenado en la variable "lr"
        lr.SetPosition(0, ray.origin);

        if (lr.positionCount != 2) lr.positionCount = 2;

        if (Physics.Raycast (ray, out hit, rayLongitud))
        {
            if (hit.collider.CompareTag("Reflejos"))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                RaycastRebotado(hit.point, hit.normal);
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);
            }

            // se establece el punto final del line renderer almacenado en la variable "lr"
            lr.SetPosition(1, hit.point);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * rayLongitud, Color.blue);

            // se establece el punto final del line renderer almacenado en la variable "lr"
            lr.SetPosition(1, ray.origin + ray.direction * rayLongitud);
        }
    }

    void RaycastSeleccionObjeto()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("ObjetoSeleccionable"))
            {
                objetoSeleccionado = hit.collider.transform;
            }
            else
            {
                objetoSeleccionado = null;
            }
        }
        else
        {
            objetoSeleccionado = null;
        }
    }

    void RaycastRebotado (Vector3 origen, Vector3 direccion)
    {
        Ray ray = new Ray(origen, direccion);
        RaycastHit hit;

        if (lr.positionCount != 3) lr.positionCount = 3;

        if (Physics.Raycast(ray, out hit, rayLongitud))
        {

            if (hit.collider.CompareTag("Reflejos"))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                RaycastRebotado_2(hit.point, hit.normal);
            }
            else
            {
                if (hit.collider.gameObject.name == "Meta")
                {
                    Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.grey);
                }
                else
                {
                    Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);
                }
            }

            lr.SetPosition(2, hit.point);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * rayLongitud, Color.blue);
            lr.SetPosition(2, ray.origin + ray.direction * rayLongitud);
        }
    }

    void RaycastRebotado_2(Vector3 origen, Vector3 direccion)
    {
        Ray ray = new Ray(origen, direccion);
        RaycastHit hit;

        if (lr.positionCount != 4) lr.positionCount = 4;

        if (Physics.Raycast(ray, out hit, rayLongitud))
        {

            if (hit.collider.CompareTag("Reflejos"))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            }
            else
            {
                if (hit.collider.gameObject.name == "Meta")
                {
                    Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.grey);
                }
                else
                {
                    Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);
                }   
            }

            lr.SetPosition(3, hit.point);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * rayLongitud, Color.blue);
            lr.SetPosition(3, ray.origin + ray.direction * rayLongitud);
        }
    }

}
