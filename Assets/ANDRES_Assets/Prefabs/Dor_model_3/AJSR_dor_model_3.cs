using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AJSR_dor_model_3 : MonoBehaviour
{
    public Boolean isOpen = true;
    //public bool onGoingAnimation;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        doTheMovement();

    }

    void doTheMovement()
    {
        if (isOpen)
        {
            openDor();
        }
        else
        {
            closeDor();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void endAnimation()
    {
        Debug.Log("[puerta] endAnimation()");
        //onGoingAnimation = false;
    }
    public void startAnimation()
    {
        Debug.Log("[puerta] startAnimation()");
        //onGoingAnimation = true;
    }

    public void openDor() {
        Debug.Log("[puerta] openDor()");
        anim.SetBool("dorIsOpen", false);
    }

    public void closeDor()
    {
        Debug.Log("[puerta] closeDor()");
        anim.SetBool("dorIsOpen", false);
    }
    public int CountChildrenOn(GameObject parent)
    {
        int count = 0;

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            Transform child = parent.transform.GetChild(i);
            /*
            if (child.GetComponent<Toggle>() != null && child.GetComponent<Toggle>().isOn)
            {
                count++;
            }
            */
        }

        return count;
    }
}