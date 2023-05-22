using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarmRedLight : MonoBehaviour
{
    public float speed = 200f; // default speed

    private void Update()
    {
        // Rotate the object around the Y-axis at a constant speed
        //transform.Rotate(0f, speed * Time.deltaTime, 0f);
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
