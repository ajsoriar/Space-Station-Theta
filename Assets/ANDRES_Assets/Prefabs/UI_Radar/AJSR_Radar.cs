using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UIElements;

public class AJSR_Radar : MonoBehaviour
{
    private float detectionRadius = 15f;
    private Transform playerTransform;
    private Vector3 playerPosition;
    //GameObject[] enemyObjectsNearMe;
    List<GameObject> enemyObjectsNearMe = new List<GameObject>(); // ChatGPT

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerObject.transform;
        Debug.Log("[Radar] Start()");

        playerPosition = playerTransform.position;
        Debug.Log("[Radar] Player position: " + playerPosition);
    }

    /*
    private void Update()
    {
        // Find all objects tagged as "Enemies" within the detection radius
        Collider[] colliders = Physics.OverlapSphere(playerTransform.position, detectionRadius, LayerMask.GetMask("Enemy"));

        // Store the coordinates of the detected enemies
        List<Vector3> enemyPositions = new List<Vector3>();
        foreach (Collider collider in colliders)
        {
            enemyPositions.Add(collider.transform.position);
        }

        // Process the enemy positions (e.g., display on radar UI, apply AI logic, etc.)
        ProcessEnemyPositions(enemyPositions);
    }
    */

    private void Update()
    {

        enemyObjectsNearMe.Clear();

        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        playerPosition = playerTransform.position;
        GameManager.THIS.playerData.totalEnemies = enemyObjects.Length;

        foreach (GameObject enemyObject in enemyObjects)
        {
            // Access the enemy object and perform operations as needed
            Vector3 enemyPosition = enemyObject.transform.position;
            Debug.Log("Enemy position: " + enemyPosition);

            float distance = Vector3.Distance(enemyPosition, playerPosition);
            Debug.Log("Distance to enemy: " + distance);

            if (distance < detectionRadius)
            {
                enemyObjectsNearMe.Add(enemyObject);
            }
        }

        int count = enemyObjectsNearMe.Count;
        
        GameManager.THIS.playerData.enemiesNearMe = enemyObjectsNearMe.Count;

        ProcessEnemyPositions(enemyObjectsNearMe);
    }

    /*
    public void CreateSphere(Vector3 position, float scale, Transform parent)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;
        sphere.transform.localScale = new Vector3(scale, scale, scale);
        sphere.transform.SetParent(parent);
    }
    */

    // Change the function i provided so so the position of the new sphere is relative to the Transform parent and not to the scene
    public void CreateSphere(Vector3 localPosition, float scale, Transform parent)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(scale, scale, scale);
        sphere.transform.SetParent(parent);
        sphere.transform.localPosition = localPosition;
    }

    // Give me a function to destroy all objects inside a children "Screen/UI"
    public void DestroyAllChildren(Transform parent)
    {
        int childCount = parent.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            Transform child = parent.GetChild(i);
            Destroy(child.gameObject);
        }
    }

    private void ProcessEnemyPositions(List<GameObject> enemiesToDraw)
    {

        // Clear the radar
        Transform uiParent = transform.Find("Screen/ENEMIES");
        DestroyAllChildren(uiParent);

        // Draw enemies in the radar

        //SphereCreator sphereCreator = GetComponent<SphereCreator>();

        // Find the parent object "Screen/ENEMIES"
        Transform parentObject = transform.Find("Screen/ENEMIES");

        if (parentObject == null)
        {
            Debug.LogError("Parent object 'Screen/ENEMIES' not found.");
            return;
        }

        /*
        foreach (GameObject enemy in enemiesToDraw)
        {
            //Vector3 enemyPosition = new Vector3(0, 0, 0);
            Vector3 enemyPosition = enemy.transform.position;
            float enemyScale = 0.02f;// 1f; // Adjust the scale of the sphere as needed

            // Create a sphere as a child of the parentObject at the enemy's position
            CreateSphere(enemyPosition, enemyScale, parentObject);
        }
        */

        // In the following piece of code, scale the position x, z of every enemy by 0.001 and set the y to 0
        foreach (GameObject enemy in enemiesToDraw)
        {
            Vector3 enemyPosition = enemy.transform.position;
            float enemyScale = 0.02f; // Adjust the scale of the sphere as needed

            // Scale the x and z positions by 0.001 and set the y position to 0
            enemyPosition.x *= 0.01f;
            enemyPosition.z *= 0.01f;
            enemyPosition.y = 0f;

            // Create a sphere as a child of the parentObject at the modified enemy's position
            CreateSphere(enemyPosition, enemyScale, parentObject);
        }

    }
}

/*
public class SphereCreator : MonoBehaviour
{
    public GameObject spherePrefab;

    public void CreateSphere(Vector3 position, float scale, Transform parent)
    {
        if (spherePrefab == null)
        {
            Debug.LogError("Sphere prefab is not assigned.");
            return;
        }

        GameObject sphere = Instantiate(spherePrefab, position, Quaternion.identity);
        sphere.transform.localScale = Vector3.one * scale;
        sphere.transform.SetParent(parent);
    }
}
*/

/*

using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public float detectionRadius = 20f;

    private Transform playerTransform;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerObject.transform;
    }

    private void Update()
    {
        // Find all objects tagged as "Enemies" within the detection radius
        Collider[] colliders = Physics.OverlapSphere(playerTransform.position, detectionRadius, LayerMask.GetMask("Enemies"));

        // Store the coordinates of the detected enemies
        List<Vector3> enemyPositions = new List<Vector3>();
        foreach (Collider collider in colliders)
        {
            enemyPositions.Add(collider.transform.position);
        }

        // Process the enemy positions (e.g., display on radar UI, apply AI logic, etc.)
        ProcessEnemyPositions(enemyPositions);
    }

    private void ProcessEnemyPositions(List<Vector3> enemyPositions)
    {
        // TODO: Implement your desired logic here
        // You can access the enemy positions and perform any actions you need
        // For example, you can display them on a radar UI or apply AI behavior to the enemies
    }
}
 
*/