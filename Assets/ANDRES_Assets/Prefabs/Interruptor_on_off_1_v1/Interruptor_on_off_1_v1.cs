using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class Interruptor_on_off_1_v1 : MonoBehaviour
{

    public Boolean isOn = false;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        doTheMovement();
        //ChangeChildObjectColor("StatusColor", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        doTheMovement();
    }
    public void RealizaAccion(int value)
    {
        Debug.Log("[interruptor] !!!!! **** raycast + click, acciona el interruptor **** !!!!!");
        reverseStatus();
        doTheMovement();
    }

    void reverseStatus()
    {
        isOn = (isOn) ? false : isOn = true; // thanks ChatGPT
    }

    void doTheMovement()
    {
        if (isOn)
        {
            isOn = true;
            anim.SetBool("isOn", true);
        }
        else
        {
            isOn = false;
            anim.SetBool("isOn", false);
        }
    }
    public void updateStatusAfterAnimation(string newStatus) { // This is called from the animation
        newStatus = newStatus.Trim().ToUpper();
        Debug.Log("[interruptor] updateStatus(), newStatus: "+ newStatus);
        if (newStatus == "ON")
        {
            Debug.Log("[interruptor] 1");
            ChangeChildObjectColor("StatusColor", Color.green);
            SetChildObjectActive("GreenLight", true);
            SetChildObjectActive("RedLight", false);
        } else if (newStatus == "OFF")
        {
            Debug.Log("[interruptor] 2");
            ChangeChildObjectColor("StatusColor", Color.red);
            SetChildObjectActive("GreenLight", false);
            SetChildObjectActive("RedLight", true);
        }
        else {
            Debug.Log("[interruptor] 3");
        }
    }

    public void ChangeChildObjectColor(string gameObjectName, Color newColor) // thanks ChatGPT
    {
        Debug.Log("[interruptor] ChangeChildObjectColor()");
        Transform childTransform = transform.Find(gameObjectName);
        if (childTransform != null)
        {
            Renderer childRenderer = childTransform.GetComponent<Renderer>();
            if (childRenderer != null)
            {
                childRenderer.material.color = newColor;
            }
        }
    }
    public void SetChildObjectActive(string childObjectName, bool active) // thanks ChatGPT
    {
        Transform childObjectTransform = transform.Find(childObjectName);
        if (childObjectTransform != null)
        {
            childObjectTransform.gameObject.SetActive(active);
        }
        else
        {
            Debug.LogError("Child object with name " + childObjectName + " not found.");
        }
    }
}
