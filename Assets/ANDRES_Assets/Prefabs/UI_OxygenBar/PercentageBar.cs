using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PercentageBar : MonoBehaviour
{  
    public static PercentageBar THIS;
    public int currentOxygenValue = 50;
    public GameObject objt;
    Vector3 scale;

    private void Awake()
    {
        if (THIS == null) {// SINGLETON
            THIS = this;
            GameManager.THIS.playerData.oxygen = 90;
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        objt = transform.Find("PercentageBarSide/percentageBar").gameObject;
        currentOxygenValue = GameManager.THIS.playerData.oxygen;
        Vector3 scale = objt.transform.localScale;
        UpdateBarLength();
    }

    //private void FixedUpdate() {
    //    //UpdateBarLength();
    //}

    private void UpdateBarLength() {
        float val = calcScale30fromPercentage(currentOxygenValue);
        Debug.Log("[Bar] New percentage: " + currentOxygenValue + "; scale.z: " + val);
        scale.z = val;
        scale.y = 1; // 6 hours of work to understand that this is mandatory!
        scale.x = 1; // 6 hours of work to understand that this is mandatory!
        objt.transform.localScale = scale;
    }

    public void refreshBar() {
        currentOxygenValue = GameManager.THIS.playerData.oxygen;
        UpdateBarLength();
    }

    /*

    //public float calcScale30fromPercentage(int percentage) {
    //    return percentage * 30 / 100; // 30 is the length of the bar.
    //}
    
    // ChatGPT, LOL! 25/05/2023

    // calcScale30fromPercentage is returning values without decimals.

    If you want the calcScale30fromPercentage function to return values with decimals, 
    you need to ensure that the percentage and 30 values are treated as floating-point 
    numbers during the calculation.Here's an updated version of the function that performs 
    the calculation with floating-point division:
    */
    public float calcScale30fromPercentage(int percentage)
    {
        return percentage * 30f / 100f; // 30f is the length of the bar, using floating-point division
    }
}