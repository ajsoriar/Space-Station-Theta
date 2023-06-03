using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.XR;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
//using AndresHelpers;

public class AJSR_Player_PrimeraPersona_2 : MonoBehaviour
{
    public static AJSR_Player_PrimeraPersona_2 THIS;

    public float rayLength;
    RaycastHit targetHitObject;

    [Range(1f, 10f)]
    public float walkSpeed;

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

    // Hands
    public Rigidbody balaOriginal;
    public GameObject HandGroup;
    public GameObject A; // = GameObject.Find("mano-pistola_v2");
    public GameObject B; // = GameObject.Find("mano-pointer");
    public GameObject C; // = GameObject.Find("mano-press2");

    // Moving
    public bool playerIsMoving = false;
    public bool playerIsRunning = false;
    private float counter = 0;
    private float counterTimer = 0;
    private int stepSound = -1; // Two different sounds for every foot. (-1 left and 1 right, stereo!)  

    //private Animation anim;
    //private Animator _animator;
    //const string PLAYER_IDLE = "Player_Alive";
    //const string PLAYER_DIES = "Player_Dies";
    //const string PLAYER_JUMP = "Player_Jump";
    //public FadeOutObject fadeOutObject;

    private void Awake()
    {
        THIS = this;
        GameManager.THIS.playerData.health = 100;
        GameManager.THIS.playerData.oxygen = 100;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        if (walkSpeed <= 0f) walkSpeed = 3f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rayLength = 100f;
        EnableHand(0);

        //_animator = gameObject.GetComponent<Animator>();
        enableGameOverTextLayer(false);
        enableDieLayer(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.THIS.playerData.isDeath) return;
   
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

        // Salto
        //if (Input.GetKeyDown(KeyCode.Space) && onGround) {
        //    float jumpForce = Mathf.Sqrt(jumpHeight * -2 * Physics.gravity.y);
        //    rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        //}

        // Run
        if (Input.GetKeyDown(KeyCode.R)) playerIsRunning = true;
        if (Input.GetKeyUp(KeyCode.R)) playerIsRunning = false;

        // ------------------------------------------------------------------------------------------------
    }

    // GameManager.THIS.playerData.health = 100;
    void manageRIP() {
        if (GameManager.THIS.playerData.oxygen <= 0 || GameManager.THIS.playerData.health <= 0) {
            die();
        } else {
            updateRIPLayer();
        }
    }
	
    void die() {
        Debug.Log("[RIP] Just Die! ");
        GameManager.THIS.playerData.isDeath = true;
        SoundManager.THIS.PlaySound_OutOfOxygen();

        enableGameOverTextLayer(true);

        // fall to the ground
        //_animator.Play(PLAYER_DIES);

        // Remove radar & Remove oxygen
        GameObject objt = transform.Find("Main_Camera_Primera_Persona/PlayerUI").gameObject;
        objt.SetActive(false);

        // remove hands
        objt = transform.Find("Main_Camera_Primera_Persona/Hands").gameObject;
        objt.SetActive(false);

        Cursor.visible = true;
    }
	
    void updateRIPLayer() {
        if (GameManager.THIS.playerData.oxygen <= 5 || GameManager.THIS.playerData.health <= 5) {
            Debug.Log("[RIP] less than 10, oxygen: " + GameManager.THIS.playerData.oxygen + "health: "+ GameManager.THIS.playerData.health);
            // Show the red layer
            GameObject gameOverRedLayer = GameObject.Find("Main_Camera_Primera_Persona/RIP/GameOverRedLayer");
            enableDieLayer(true);
            Vector3 newPosition = gameOverRedLayer.transform.localPosition;
            newPosition.z += 0.04f;
            gameOverRedLayer.transform.localPosition = newPosition;
        } else {
            Debug.Log("[RIP] more than 5");
            // Hide the red layer
            enableDieLayer(false);
        }
    }

    void enableDieLayer(bool enable) {
        GameObject gameOverRedLayer = GameObject.Find("Main_Camera_Primera_Persona/RIP/GameOverRedLayer");
        gameOverRedLayer.SetActive(enable);
    }

    void enableGameOverTextLayer(bool enable) {
        GameObject gameOverRedLayer = GameObject.Find("Main_Camera_Primera_Persona/RIP/GameOverText");
        gameOverRedLayer.SetActive(enable);
    }

    private void FixedUpdate() {
        if (GameManager.THIS.playerData.isDeath) return;

        SetMoveAndRotationByPhysics();
        CamRaycast();

        // public int speedBootsSteps;
        // public int speedBootsVelocity;

        UpdateTextMesh("HolaText2",
            "isMoving: " + playerIsMoving + "\n" + "velocity, x:" + moveVector.x + ", z:" + moveVector.z +"\n" +
            "Coins: "+ GameManager.THIS.playerData.coinsCounter +"\n" +
            "Keys: " + GameManager.THIS.playerData.keysCounter +"\n" +
            "oxigenBotleCount: " + GameManager.THIS.playerData.oxygenBotleCount + "\n" +
            "oxigen: " + GameManager.THIS.playerData.oxygen + "\n" +
            "healthCaseCount: " + GameManager.THIS.playerData.healthCaseCount + "\n" +
            "health: " + GameManager.THIS.playerData.health + "\n" +
            "currentWeapon: " + GameManager.THIS.playerData.currentWeapon + "\n" +
            "bulletsCounter: " + GameManager.THIS.playerData.bulletsCounter + "\n" +
            "weaponTemperature: " + GameManager.THIS.playerData.weaponTemperature + "\n" +
            "totalEnemies: " + GameManager.THIS.playerData.totalEnemies + "\n" +
            "enemiesNearMe: " + GameManager.THIS.playerData.enemiesNearMe + "\n" +
            "speedBootsSteps: " + GameManager.THIS.playerData.speedBootsSteps + "\n" +
            "speedBootsVelocity: " + GameManager.THIS.playerData.speedBootsVelocity + "\n" +
            "."
        );

        printScreenInfo();

        if (moveVector.x != 0f && moveVector.z != 0f) {
            playerIsMoving = true;
        } else {
            playerIsMoving = false;
        }

        if (playerIsMoving) {
            if (counterTimer >= calcMovTime() || (counter == 0 && counterTimer == 0f)) { // Increase counter every step;
                counter++;
                counterTimer = 0f;
                walkSound();
                decreaseOxigenOpeStep();
                decreaseBootsStep();
                manageRIP();
            }   
            counterTimer += Time.deltaTime;
        } else {
            // Reset the counter and timer if the player is not moving
            counter = 0;
            counterTimer = 0f;
        }
    }

    // ---- Info bars ----
    void printScreenInfo() {
        if (GameManager.THIS.playerData.speedBootsSteps > 0) {
            UpdateTextMesh("txtSpeedBoots",
                "Velocity: x" + GameManager.THIS.playerData.speedBootsVelocity +
                " Steps: " + GameManager.THIS.playerData.speedBootsSteps
            );
        } else {
            UpdateTextMesh("txtSpeedBoots"," ");
        }

        UpdateTextMesh("txtKeysCounter", "Keys: " + GameManager.THIS.playerData.keysCounter);
        UpdateTextMesh("txtCoinsCounter", "Coins: " + GameManager.THIS.playerData.coinsCounter);
    }

    void walkSound() {
        if (stepSound == 1){
            SoundManager.THIS.PlaySound_FootRight();
        } else { // -1
            SoundManager.THIS.PlaySound_FootLeft();
        }
    }

    float calcPlayerMovSpeed() {
        if (GameManager.THIS.playerData.speedBootsSteps > 0) return (walkSpeed * GameManager.THIS.playerData.speedBootsVelocity);
        if (playerIsRunning) return (walkSpeed * 2);
        return walkSpeed;
    }

    float calcMovTime() {
        if (GameManager.THIS.playerData.speedBootsSteps > 0) return (0.5f / GameManager.THIS.playerData.speedBootsVelocity);
        if (playerIsRunning) return (0.5f/2);
        return 0.5f;
    }

    public void decreaseOxigenOpeStep() {
        Debug.Log("[Steps] decreaseOxigenOpeStep()");
        GameManager.THIS.playerData.oxygen -= 1;
        PercentageBar.THIS.refreshBar();
    }

    void decreaseBootsStep() {
        if (GameManager.THIS.playerData.speedBootsSteps > 0) {
            GameManager.THIS.playerData.speedBootsSteps -= 1;
        }
    }

    public void decreaseHeath(int decValue) {
        Debug.Log("[Health] decreaseHeath()");
        if (decValue == 0) decValue = 1;
        int curr = GameManager.THIS.playerData.health;
        if ( (curr - decValue)<= 0 ) {
            GameManager.THIS.playerData.health = 0;
        } else {
            GameManager.THIS.playerData.health -= decValue;
        }
        PlayerHealthBar.THIS.refreshBar();
        manageRIP();
    }

    void SetVectors() {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.z = Input.GetAxisRaw("Vertical");
        moveVector = inputVector.x * cam.right + inputVector.z * cam.forward;
        moveVector.y = 0f;
        moveVector = moveVector.normalized;
    }

    void SetRotationAngles() {
        verticalAnglesAngles -= Input.GetAxis("Mouse Y") * speedRot * Time.deltaTime;
        verticalAnglesAngles = Mathf.Clamp(verticalAnglesAngles, -limitAngles, limitAngles);
        cam.localRotation = Quaternion.Euler(Vector3.right * verticalAnglesAngles);
        horizontalAngles += Input.GetAxis("Mouse X") * speedRot;
    }

    void SetMoveAndRotationByPhysics() {
        rb.MovePosition(rb.position + moveVector * calcPlayerMovSpeed() * Time.fixedDeltaTime);
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
	
    public void setTarget(RaycastHit hit) {
        targetHitObject = hit;
        //AndresHelpers.
        UpdateTextMesh("txtMessage", targetHitObject.collider.gameObject.name);
        EnableHand(1);
    }
	
    public void EnableHand(int index) {
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