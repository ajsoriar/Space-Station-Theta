using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

public class RotateForever : MonoBehaviour
{
    float speed = -200f;

    private void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime, Space.Self);
    }

    /*
    public float rotationSpeed;
    public Vector3 rotationAxis = Vector3.up;
    public Transform pivotPoint;

    private void Start()
    {
        if (rotationSpeed < 100) { 
            rotationSpeed = -200f;
        }
        
        if (pivotPoint == null)
        {
            pivotPoint = transform;
        }

        StartCoroutine(RotateObject());
    }

    private IEnumerator RotateObject()
    {
        while (true)
        {
            //transform.RotateAround(pivotPoint.position, rotationAxis, rotationSpeed * Time.deltaTime);
            transform.RotateAround(pivotPoint.localPosition, rotationAxis, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }

    */

}

/*
public class RotateForever : MonoBehaviour
{
    public float rotationSpeed = -200f;
    public Vector3 rotationAxis = Vector3.up;
    public Transform pivotPoint;

    private void Start()
    {
        if (pivotPoint == null)
        {
            pivotPoint = transform;
        }

        StartCoroutine(RotateObject());
    }

    private IEnumerator RotateObject()
    {
        while (true)
        {
            transform.RotateAround(pivotPoint.localPosition, rotationAxis, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
}

*/