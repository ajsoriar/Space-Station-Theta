using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_PrimeraPersona : MonoBehaviour
{
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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        if (speedMov <= 0f) speedMov = 3f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        SetVectors();
        SetRotationAngles();
    }

    private void FixedUpdate()
    {
        SetMoveAndRotationByPhysics();
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

}