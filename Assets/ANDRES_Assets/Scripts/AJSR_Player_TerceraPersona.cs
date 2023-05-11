using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AJSR_Player_TerceraPersona : MonoBehaviour
{

    public float xInput;
    public float zInput;

    Vector3 moveVector;

    Transform cam;
    public Rigidbody rb;
    public Transform origin;

    public float vel;
    public int coins;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        if (vel < 0) vel = 2;
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");

        moveVector = cam.right * xInput + cam.forward * zInput;

        moveVector.y = 0f;
        moveVector = moveVector.normalized; // normalized Retorna el mismo vector pero en base 1. Para que el movimiento tenga la misma velocidad en todas las direcciones. 

        // rotacion
        if (moveVector.magnitude != 0f) { // Si se ha presionado una tecla

            //Debug.Log("player en movimiento, Si presionas alguna tecla");

            // OPCION A. 
            transform.forward = moveVector * vel;
            
            // OPCION B. Se accede a la propiedad de la rotacion y se asigna el resultado 
            // una rotacion basada en una direccion frontal
            //transform.rotation = Quaternion.LookRotation(moveVector);

        } else {
            // Player quieto
        }

        if (Input.GetMouseButtonDown(0)){
            disparo();
        }
    }

    private void FixedUpdate() {
        // traslacion sincronizada con fisicas
        rb.MovePosition(rb.position + moveVector * Time.fixedDeltaTime);
        playerRayo();
        cameraRayo();
    } 

    void playerRayo(){
        // Definicion del rayo Invisible o Raycast...
        Ray ray = new Ray( origin.position, origin.forward); 
        RaycastHit hit; // variable que almacenara datos extendidos de la variable ray

        if (Physics.Raycast( ray, out hit, 5f)){
            //Debug.Log("El raycast del munyeco detecta: "+ hit.collider.gameObject.name);
            Debug.DrawRay(ray.origin,ray.direction * hit.distance, Color.red);
        } else {
            //Debug.Log("El raycast no detecta nada!");
            Debug.DrawRay(ray.origin,ray.direction * 5, Color.green);
        }
    }

    void cameraRayo(){
        // Definicion del rayo Invisible o Raycast...
        Ray ray = new Ray( cam.position, cam.forward); 
        RaycastHit hit; // variable que almacenara datos extendidos de la variable ray

        if (Physics.Raycast( ray, out hit, 5f)){
            //Debug.Log("El raycast de la camara detecta: "+ hit.collider.gameObject.name);
            Debug.DrawRay(ray.origin,ray.direction * hit.distance, Color.red);
        } else {
            //Debug.Log("El raycast no detecta nada!");
            Debug.DrawRay(ray.origin,ray.direction * 5, Color.green);
        }
    }

    void disparo(){
        Debug.Log("Diparo!");

        //Rigidbody clonDisparo = Instantiate(balaOriginal, cam.position, cam.rotation);
        //clonDisparo.AddForce(clonDisparo.transform.forward * 50f, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider otherTrigger) {
        Debug.Log("OnTriggerEnter! El player entra en el trigger del objeto que se llama "+ otherTrigger.gameObject.name);

        // Cuando el player entra en un objeto que tenga un Collider con la propiedad triger a true!

        if (otherTrigger.gameObject.CompareTag("Monedas")){
            otherTrigger.gameObject.SetActive(false);
            coins++;
        }

        if (otherTrigger.gameObject.CompareTag("Puertas")){
            otherTrigger.GetComponent<Animator>().SetBool("estadoPuerta", true);
        }    

    }

    private void OnTriggerExit(Collider otherTrigger) {
        Debug.Log("OnTriggerEnter! El player entra en el trigger del objeto que se llama "+ otherTrigger.gameObject.name);


        if (otherTrigger.gameObject.CompareTag("Puertas")){
            otherTrigger.GetComponent<Animator>().SetBool("estadoPuerta", false);
        }    

    }
}
