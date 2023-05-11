using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Aranna : MonoBehaviour
{
    /// <summary>
    /// 
    /// Cuando Jugador entra en el interior del trigger de la araña pasa lo siguiente:
    /// 
    /// 1) Su torreta apunta hacia el Jugador...
    /// 2) Su torreta dispara cada 0.2 segundos hacia el jugador
    /// 3) La torreta de la araña solo dispara cuando se cumple la siguiente condicion:
    ///     jugador dentro del trigger de la araña Y raycast de la araña detecta a jugador
    /// 
    /// </summary>

    // ********************************************************
    #region 1) Definicion Variables
    NavMeshAgent agente;
    Transform jugador;
    Coroutine disparoTorretaCoro;

    public bool jugadorDetectado;

    public ArannaTorretaEstados estadoTorreta;

    public Transform torretaOrigen;
    public Transform torretaOrigenBalas;

    public float tiempoEntreDisparos;

    public Rigidbody balaOriginal;

    #endregion
    // ********************************************************
    #region 2) Funciones Unity
    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (jugadorDetectado)
        {
            #region Raycast para el comienzo de los disparos
            Vector3 a = torretaOrigenBalas.position;
            Vector3 b = jugador.position;
            b.y = a.y;

            Vector3 direccionRayo = b - a;

            Ray ray = new Ray(torretaOrigen.position, direccionRayo);
            RaycastHit hit;

            if (Physics.Raycast (ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                float grados = Vector3.Angle(torretaOrigen.forward, b - a);

                if (grados < 10f)
                {
                    Debug.DrawRay(ray.origin, torretaOrigenBalas.forward, Color.red);

                    if (estadoTorreta != ArannaTorretaEstados.Disparando)
                    {
                        EstablecerEstado_Torreta(ArannaTorretaEstados.Disparando);
                    }
                }
                else
                {
                    Debug.Log("Aranna apuntando");
                    Debug.DrawRay(ray.origin, torretaOrigenBalas.forward, Color.yellow);

                    if (estadoTorreta != ArannaTorretaEstados.Apuntando)
                    {
                        EstablecerEstado_Torreta(ArannaTorretaEstados.Apuntando);
                    }
                }

                if (hit.collider.CompareTag("Player"))
                {
 
                }
                else
                {
                    Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);
                }
            }
            #endregion

            #region Rotacion
            // Rotacion directa
            //Vector3 objetivo = new Vector3(jugador.position.x, torretaOrigen.position.y, jugador.position.z);
            //torretaOrigen.LookAt(objetivo);

            #region Rotacion suavizada y progresiva

            Quaternion rotInicial = torretaOrigen.rotation;

            Vector3 direccionFrontal = jugador.position - transform.position;
            direccionFrontal.y = 0f;
            direccionFrontal = direccionFrontal.normalized;

            Quaternion rotFinal = Quaternion.LookRotation(direccionFrontal);
            torretaOrigen.rotation = Quaternion.RotateTowards(rotInicial, rotFinal, 120f * Time.deltaTime);
            #endregion
            #endregion
        }
        else
        {
            // Rotacion directa
            //torretaOrigen.forward = transform.forward;

            #region Rotacion suavizada y progresiva
            Quaternion rotInicial = torretaOrigen.rotation;
            Quaternion rotFinal = Quaternion.identity;

            torretaOrigen.rotation = Quaternion.RotateTowards(rotInicial, rotFinal, 240f * Time.deltaTime);
            #endregion

            if (torretaOrigen.rotation == Quaternion.identity && estadoTorreta != ArannaTorretaEstados.Reposo)
            {
                EstablecerEstado_Torreta(ArannaTorretaEstados.Reposo);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            jugadorDetectado = true;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            jugadorDetectado = false;
        }
    }

    #endregion
    // ********************************************************
    #region 3) Metodos Originales
    void EstablecerEstado_Torreta(ArannaTorretaEstados nuevoEstadoTorreta)
    {
        estadoTorreta = nuevoEstadoTorreta;

        switch (estadoTorreta)
        {
            // -----------------------------------------------
            case ArannaTorretaEstados.Reposo:

                Para_DisparoTorretaCoro();
                break;
            // -----------------------------------------------
            case ArannaTorretaEstados.Apuntando:

                Para_DisparoTorretaCoro();
                break;
            // -----------------------------------------------
            case ArannaTorretaEstados.Disparando:

                Comienza_DisparoTorretaCoro();
                break;
            // -----------------------------------------------
        }
    }

    void Comienza_DisparoTorretaCoro()
    {
        if (disparoTorretaCoro == null)
        {
            disparoTorretaCoro = StartCoroutine(DisparoTorretaCoro());
        }
    }

    void Para_DisparoTorretaCoro()
    {
        if (disparoTorretaCoro != null)
        {
            StopCoroutine(disparoTorretaCoro);
            disparoTorretaCoro = null;
        }
    }

    IEnumerator DisparoTorretaCoro()
    {
        while (true)
        {

            // Creacion de bala
            Rigidbody clon = Instantiate(balaOriginal, torretaOrigenBalas.position, torretaOrigenBalas.rotation);

            clon.AddForce(clon.transform.forward * 5f, ForceMode.Impulse);

            Destroy(clon.gameObject, 5f);

            yield return new WaitForSeconds(tiempoEntreDisparos);
        }
    }
    #endregion
    // ********************************************************
}

public enum ArannaEstados
{
    Quieta,
    SiguePlayer
}

public enum ArannaTorretaEstados
{
    Reposo,
    Apuntando,
    Disparando
}
