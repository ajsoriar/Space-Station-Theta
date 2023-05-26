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

    // Change the function I provided so the position of the new sphere is relative to the Transform parent and not to the scene
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
        // 1. Clear the radar
        Transform uiParent = transform.Find("Screen/ENEMIES");
        DestroyAllChildren(uiParent);

        // 2. Draw enemies in the radar

        // Find the parent object "Screen/ENEMIES"
        Transform parentObject = transform.Find("Screen/ENEMIES");

        if (parentObject == null)
        {
            Debug.LogError("Parent object 'Screen/ENEMIES' not found.");
            return;
        }

        // In the following piece of code, scale the position x, z of every enemy by 0.001 and set the y to 0
        foreach (GameObject enemy in enemiesToDraw)
        {
            Vector3 enemyPosition = enemy.transform.position;
            float enemyScale = 0.02f; // Adjust the scale of the sphere as needed

            enemyPosition.x -= playerPosition.x;
            enemyPosition.y -= playerPosition.y;

            // Scale the x and z positions by 0.001 and set the y position to 0
            enemyPosition.x *= 0.01f;
            enemyPosition.z *= 0.01f;
            enemyPosition.y = 0f;

            // Create a sphere as a child of the parentObject at the modified enemy's position
            CreateSphere(enemyPosition, enemyScale, parentObject);
        }

    }
}