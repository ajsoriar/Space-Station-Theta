using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.XR;
//using AndresHelpers;

public class AJSR_Player_PrimeraPersona_2 : MonoBehaviour
{
    public static AJSR_Player_PrimeraPersona_2 THIS;

    public float rayLength;
    RaycastHit targetHitObject;

    [Range(1f, 10f)]
    public float speedMov;

    [Range(1f, 100f)]
    public float speedRot;

    [Range(0f, 90f)]
    public float limitAngles;

    Vector3 inputVector;
    Vector3 moveVector;

    Transform cam;
    Rigidbody rb;

    float horizontalAngles;
    float verticalAnglesAngles;

    public Rigidbody balaOriginal;

    public GameObject HandGroup;
    public GameObject A; // = GameObject.Find("mano-pistola_v2");
    public GameObject B; // = GameObject.Find("mano-pointer");
    public GameObject C; // = GameObject.Find("mano-press2");
    public bool playerIsMoving = false;
    private void Awake()
    {
        THIS = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;

        if (speedMov <= 0f) speedMov = 3f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rayLength = 100f;

        InitHands();
        EnableHand(0);
    }

    private void InitHands()
    {
        //throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        SetVectors();
        SetRotationAngles();

        if (Input.GetMouseButtonDown(0) && targetHitObject.collider != null)
        {
            Debug.Log("[puerta] !!!!! **** El raycast detecta un elemento interactivo **** !!!!!");

            StartCoroutine(moveHandForward(HandGroup));

            // Call the "DoSomething" function on the hit object
            targetHitObject.collider.gameObject.SendMessage("RealizaAccion", 1);
        }
        else if (Input.GetMouseButtonDown(0)) // Si hago click izquierdo del raton...
        {
            StartCoroutine(moveHandForward(HandGroup, -0.5f));
            Disparo();
            SoundManager.THIS.PlaySound_ShotWeapon();
        }

        /*
        float velocityMagnitude = rb.velocity.magnitude;
        string velocityString = velocityMagnitude.ToString("F2");
        */
    }

    private void FixedUpdate()
    {
        SetMoveAndRotationByPhysics();
        CamRaycast();

        UpdateTextMesh("HolaText2",
            "isMoving: " + playerIsMoving + "\n" + "velocity, x:" + moveVector.x + ", z:" + moveVector.z +"\n" +
            "Coins: "+ GameManager.THIS.playerData.coinsCounter +"\n" +
            "Keys: " + GameManager.THIS.playerData.keysCounter +"\n" +
            "oxigen: " + GameManager.THIS.playerData.oxigen + "\n" +
            "damage: " + GameManager.THIS.playerData.damage + "\n" +
            "currentWeapon: " + GameManager.THIS.playerData.currentWeapon + "\n" +
            "bulletsCounter: " + GameManager.THIS.playerData.bulletsCounter + "\n" +
            "weaponTemperature: " + GameManager.THIS.playerData.weaponTemperature + "\n" +
            "."
        );

    //public float oxigen;
    //public float oxigenMax;
    //public float damage;
    //public float damageMax;

    //// Weapons
    //public int currentWeapon; // 0 Hands, 1 Basic, 2 Bazooka, 3 LoveYou!
    //public int bulletsCounter;
    //public float weaponTemperature;
    //public float weaponTemperatureMax;

    //// Skils
    //public bool fastRunUnlocked;
    //public bool jumpUnlocked;
    //public bool energyShieldUnlocked;

    //// Items
    //public int coinsCounter;
    //public int keysCounter;

        if (moveVector.x != 0f && moveVector.z != 0f) {
            playerIsMoving = true;
        } else {
            playerIsMoving = false;
        }
    }

    void SetVectors()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.z = Input.GetAxisRaw("Vertical");
        moveVector = inputVector.x * cam.right + inputVector.z * cam.forward;
        moveVector.y = 0f;
        moveVector = moveVector.normalized;
    }

    void SetRotationAngles()
    {
        verticalAnglesAngles -= Input.GetAxis("Mouse Y") * speedRot * Time.deltaTime;
        verticalAnglesAngles = Mathf.Clamp(verticalAnglesAngles, -limitAngles, limitAngles);
        cam.localRotation = Quaternion.Euler(Vector3.right * verticalAnglesAngles);
        horizontalAngles += Input.GetAxis("Mouse X") * speedRot;
    }

    void SetMoveAndRotationByPhysics()
    {
        rb.MovePosition(rb.position + moveVector * speedMov * Time.fixedDeltaTime);
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * horizontalAngles * Time.fixedDeltaTime);
        rb.MoveRotation(deltaRotation);
    }





    // playerInRadioactiveArea
    // playerInLava

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RadioactiveArea"))
        {
            //playerInRadioactiveArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("RadioactiveArea"))
        {
            //playerInRadioactiveArea = false;
            //playerInRadioactiveAreaTimer = 0f;
        }
    }






    public IEnumerator moveHandForward(GameObject hand, float distanceToMove = 0.5f)
    {
        float moveDuration = 1f;

        Vector3 startPosition = hand.transform.position;
        Vector3 endPosition = hand.transform.position + hand.transform.forward * distanceToMove;

        float currentTime = 0f;
        while (currentTime < moveDuration)
        {
            currentTime += Time.deltaTime;
            float t = Mathf.Clamp01(currentTime / moveDuration);
            hand.transform.position = Vector3.Lerp(endPosition, startPosition, t);
            yield return null;
        }
        hand.transform.position = startPosition;
    }

    //void Disparo()
    //{
    //    Transform PlayerGunOriginTransform = transform.Find("Main_Camera_Primera_Persona/PlayerGunOrigin");
    //    //Rigidbody clonDisparo = Instantiate(balaOriginal, cam.position, cam.rotation);
    //    Rigidbody clonDisparo = Instantiate(balaOriginal, PlayerGunOriginTransform.position, PlayerGunOriginTransform.rotation);
    //    clonDisparo.AddForce(clonDisparo.transform.forward * 50f, ForceMode.Impulse);
    //}

    void Disparo()
    {
        Transform PlayerGunOriginTransform = transform.Find("Main_Camera_Primera_Persona/PlayerGunOrigin");
        Rigidbody clonDisparo = Instantiate(balaOriginal, PlayerGunOriginTransform.position, PlayerGunOriginTransform.rotation);
        clonDisparo.AddForce(clonDisparo.transform.forward * 50f, ForceMode.Impulse);

        // Destroy the projectile object after 5 seconds
        Destroy(clonDisparo.gameObject, 5f);
    }

    void CamRaycast()
    {
        Ray ray = new Ray(cam.position, cam.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            Debug.Log("El raycast de la camara detecta: " + hit.collider.gameObject.name);

            if (hit.collider.gameObject.CompareTag("Interruptores")) // TODO: Sustituir por "interactivo".
            {
                if (hit.distance < 1.5) // TODO: Obtener valor umbralDeInteraccion de cada objeto.
                {
                    Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 0);
                    setTarget(hit);
                }
                else
                {
                    Debug.DrawRay(ray.origin, ray.direction * hit.distance, new Color(1f, 0.5f, 0.8f), 0);
                    clearTarget();
                }
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.cyan, 0);
                clearTarget();
            }
        }
        else
        {
            Debug.Log("El raycast de la camara no detecta nada");
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.green, 0);
            clearTarget();
        }

        //AndresHelpers.
        UpdateTextMesh("txtDistanceInfo", hit.distance.ToString());
    }

    public void clearTarget()
    {
        //AndresHelpers.
        UpdateTextMesh("txtMessage", "");
        targetHitObject = default;
        EnableHand(0);
    }

    public void setTarget(RaycastHit hit)
    {
        targetHitObject = hit;
        //AndresHelpers.
        UpdateTextMesh("txtMessage", targetHitObject.collider.gameObject.name);
        EnableHand(1);
    }
    public void EnableHand(int index)
    {
        if (index < 0 || index >= 3)
        {
            Debug.LogWarning("Invalid index: " + index);
            return;
        }

        GameObject[] gameObjects = new GameObject[] { A, B, C };

        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (i == index)
            {
                gameObjects[i].SetActive(true);
            }
            else
            {
                gameObjects[i].SetActive(false);
            }
        }
    }

    // move to utils library?
    public void UpdateTextMesh(string textMeshName, string newText) // Thanks ChatGPT
    {
        GameObject gameObjectWithTextMesh = GameObject.Find(textMeshName);
        if (gameObjectWithTextMesh != null)
        {
            TextMesh textMeshComponent = gameObjectWithTextMesh.GetComponentInChildren<TextMesh>();
            if (textMeshComponent != null)
            {
                textMeshComponent.text = newText;
            }
            else
            {
                Debug.LogError("No TextMesh component found on game object: " + textMeshName);
            }
        }
        else
        {
            Debug.LogError("Could not find game object: " + textMeshName);
        }
    }

}