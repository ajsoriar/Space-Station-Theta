using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GunTower_1_v1 : MonoBehaviour
{

    // -> 1f rotacion sentido agujas reloj -> -1f rotacion contraria sentido agujas reloj
    public float direccionRot;
    public float velocidadRot;
    public Transform cabeza;
    public Coroutine cambioDireccionRotCoro;
    Transform playerObjectTransform;
    float previousAngle = 0;
    float currentAngle = 0;
    //bool playerFueDetectado = false;
    String status = "ROTATING";
    private float timer = 0f;

    void Start()
    {
        if (direccionRot != 1f || direccionRot != -1f) direccionRot = -1f;
        if (velocidadRot <= 0f) velocidadRot = 15f;
        playerObjectTransform = GameObject.Find("PlayerCapsule").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (status == "ROTATING") { 
        
             // rotacion a lo largo del eje y
            cabeza.Rotate(new Vector3(0f, 1f, 0f) * direccionRot * velocidadRot * Time.deltaTime);
            GunRaycast();

            previousAngle = currentAngle;
            (float angle, float distance) = GunToPlayerRaycast();
            currentAngle = angle;
            UpdateTextMesh("txtAngleToGamer", angle.ToString("F2"));
            //Debug.Log("Angle: " + angle);
            //Debug.Log("Distance: " + distance);

            //if (playerFueDetectado) { 
            //    if (crecemosEnAngulo(previousAngle, currentAngle)) { // canyon se aleja del player => cambiar de sentido
            //        status = "PLAYER_DETECTED";
            //    }     
            //}
        }

        if (status == "PLAYER_DETECTED")
        {
            Invoke("RotateAgain", 3f);
        }

        if (currentAngle < 10) {
            dispara();
        }
    }

    private void RotateAgain()
    {
        CambioDireccionRotacion();
        status = "ROTATING";
    }

    private void dispara()
    {
        //throw new NotImplementedException();
    }

    bool crecemosEnAngulo(float previousAngle, float currentAngle) {
        if (previousAngle < currentAngle)
        {
            return true;
        }
        return false;
    }

    void CambioDireccionRotacion()
    {
        if (timer < 2f)
        {
            timer += Time.deltaTime;
        }
        else
        {
            // Call your function here
            direccionRot = -direccionRot;

            // Reset the timer
            timer = 0f;
        }     
    }

    void GunRaycast()
    {
        Transform childObjectTransform = transform.Find("Tower/Gun/GunMouth");
        Ray ray = new Ray(childObjectTransform.position, childObjectTransform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 200))
        {
            //Debug.Log("[Torreta] hit.collider.gameObject.name: "+ hit.collider.gameObject.name);
            if (hit.collider.gameObject.name == "PlayerCapsule")
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                //playerFueDetectado = true;
                status = "PLAYER_DETECTED";
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.cyan);
            }
        }
        else {
            Debug.DrawRay(ray.origin, ray.direction * 200, Color.blue);
        }
    }

    (float, float) GunToPlayerRaycast()
    {
        Transform childObjectTransform = transform.Find("Tower/Gun/GunMouth");
        //Transform playerObjectTransform = transform.Find("PlayerCapsule");
        Vector3 directionToPlayer = playerObjectTransform.position - childObjectTransform.position;
        Ray ray = new Ray(childObjectTransform.position, playerObjectTransform.position);
        float angle = 0;
        float distance = 0;
        
        RaycastHit hit;
        if (Physics.Raycast(childObjectTransform.position, directionToPlayer, out hit))
        {
            // Calculate the angle between the two raycasts
            angle = Vector3.Angle(childObjectTransform.forward, hit.point - childObjectTransform.position);

            // Calculate the distance between the two objects
            distance = Vector3.Distance(childObjectTransform.position, hit.point);

            // Draw a ray from the GunMouth to the hit point
            Debug.DrawRay(childObjectTransform.position, playerObjectTransform.position - childObjectTransform.position, Color.black);

            // Do something with the angle and distance
            //Debug.Log("[Tower] Angle between raycasts: " + angle);
            //Debug.Log("[Tower] Distance to player: " + distance);
        }
        return (angle, distance);
    }

    public float AngleBetweenRays(Ray ray1, Ray ray2)
    {
        Vector3 dir1 = ray1.direction.normalized;
        Vector3 dir2 = ray2.direction.normalized;
        float angle = Mathf.Acos(Vector3.Dot(dir1, dir2)) * Mathf.Rad2Deg;
        return angle;
    }

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

