using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AJSR_Interruptor_puerta_2 : MonoBehaviour
{
    GameObject A; //= GameObject.Find("Dor_A");
    GameObject B; //= GameObject.Find("Dor_B");

    public bool dorIsOpen;
    Animator anim;
    public bool onGoingAnimation;
    public bool buttonDisabled;

    void Start() {

        onGoingAnimation = false;
        //anim = transform.parent.gameObject.GetComponent<Animator>();
        anim = FindParentWithTag("index").GetComponent<Animator>();
        Debug.Log("[puerta] El objeto padre es: " + transform.parent.gameObject.name);

        GameObject A = GameObject.Find("Dor_1");
        GameObject B = GameObject.Find("Dor_2");
        Debug.Log("[puerta] La puerta 1 es el objeto: " + A.name);
        Debug.Log("[puerta] La puerta 2 es el objeto: " + B.name);
        Debug.Log("[puerta] dorIsOpen: " + dorIsOpen);

        if (dorIsOpen)
        {
            Debug.Log("[puerta] The dor is closed");
            AbrePuerta();
        } else {
            Debug.Log("[puerta] The dor is open");
            CierraPuerta();
        }

    }

    // Update is called once per frame
    void Update() {

    }

    public void RealizaAccion(int value) {
        Debug.Log("[puerta] !!!!! **** raycast + click, acciona el interruptor **** !!!!!");
        AbreCierra();
    }

    public void AbreCierra() {
        //if (onGoingAnimation) return;
        onGoingAnimation = true;
        dorIsOpen = anim.GetBool("puertaAbierta");
        if (dorIsOpen)
        {
            CierraPuerta();
        } else {
            AbrePuerta();
        }
    }

    public void EndAnimation() {
        onGoingAnimation = false;
    }

    public void AbrePuerta()
    {   
        Debug.Log("[puerta] !!!!! **** ABRIR puerta **** !!!!!");
        dorIsOpen = true;
        anim.SetBool("puertaAbierta", true);
    }

    public void CierraPuerta()
    {
        Debug.Log("[puerta] !!!!! **** CERRAR puerta **** !!!!!");
        dorIsOpen = false;
        anim.SetBool("puertaAbierta", false);
    }

    public GameObject FindParentWithTag(string tag, GameObject childObject = null, int maxDepth = 10) // thanks ChatGPT
    {
        if (childObject == null) childObject = gameObject;

        Transform parent = childObject.transform.parent;
        if (parent == null || maxDepth <= 0)
        {
            return null;
        }

        if (parent.CompareTag(tag))
        {
            return parent.gameObject;
        }

        return FindParentWithTag(tag, parent.gameObject, maxDepth - 1);
    }

}