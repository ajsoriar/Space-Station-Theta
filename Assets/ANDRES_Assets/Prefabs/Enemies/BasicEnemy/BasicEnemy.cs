using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public GameObject player;
    public bool isPlayerNear = false;
    public float checkInterval = 3f;
    public float playerDistanceThreshold = 10f;
    public Rigidbody bulletObject;
    Coroutine isShootingNow;
    public bool varDoTheShoot = false;

    private void Start() {
        Debug.Log("[Shoot] Start()");
        if (checkInterval == 0) checkInterval = 10f;
        if (playerDistanceThreshold == 0) playerDistanceThreshold = 10f;
        //speed = GetRandomVelocity();
        player = GameObject.FindGameObjectWithTag("Player");
        //InvokeRepeating("CheckPlayerDistance", 0f, checkInterval);
        //InvokeRepeating("DoTheShoot", 0f, checkInterval);
    }

    private void Update() {
        CheckPlayerDistance();
        if (isPlayerNear) {
            Debug.Log("[Shoot] Player is near!");
            Start_Shooting();
        } else {
            Stop_Shooting();
        }
    }

    private void CheckPlayerDistance() {
        if (player != null) {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            isPlayerNear = distance <= playerDistanceThreshold;
        }
    }

    IEnumerator DoTheShoot() {
        Debug.Log("[Shoot] DoTheShoot()");
        while (true) {
            varDoTheShoot = true;
            Transform childObjectTransform1 = transform.Find("eye/GunMouth_1");
            Rigidbody clon1 = Instantiate(bulletObject, childObjectTransform1.position, childObjectTransform1.rotation);
            clon1.AddForce(clon1.transform.forward * 20f, ForceMode.Impulse);
            Destroy(clon1.gameObject, 1f);
            yield return new WaitForSeconds(0.4f);
        }
    }

    void Start_Shooting() {
        if (isShootingNow == null) {
            isShootingNow = StartCoroutine(DoTheShoot());
        }
    }

    void Stop_Shooting() {
        if (isShootingNow != null) {
            varDoTheShoot = false;
            StopCoroutine(isShootingNow);
            isShootingNow = null;
        }
    }

}
