using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.AxisState;

public class PlayerJump : MonoBehaviour
{
    public static PlayerJump THIS;

    Rigidbody rb;

    public float saltoAltura;

    private void Awake()
    {
        THIS = this;
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (saltoAltura <= 0f) saltoAltura = 2.2f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && PlayerController.THIS.EstaPlayerEnSuelo())
        if (Input.GetKeyDown(KeyCode.Space) ) // && PlayerController.THIS.EstaPlayerEnSuelo())
        {
            Debug.Log("[jump] Van Halen!");
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            float jumpForce = Mathf.Sqrt(saltoAltura * -2f * Physics.gravity.y);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            //PlayerController.THIS.EstablecerEstadoSaltando(true);
            //ControlPlayer_Animator.THIS.Animator_EstablecerParamBool("saltando", true);
        }
    }

}
