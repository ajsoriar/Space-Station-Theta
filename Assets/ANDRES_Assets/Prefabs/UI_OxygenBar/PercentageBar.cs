using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PercentageBar : MonoBehaviour
{
    public int initialValue = 100;

    void Start()
    {
        if (initialValue > 100)
        {
            initialValue = 100;
        }
        else if (initialValue < 0)
        {
            initialValue = 0;
        }

        SetPercentage(initialValue);
    }

    void Update()
    {

    }


    public void SetPercentage(int newPercentageValue)
    {
        GameObject objt = transform.Find("PercentageBarSide/percentageBar").gameObject;
        Vector3 scale = objt.transform.localScale;

        float val = newPercentageValue * 30 / 100;
        Debug.Log("[Bar] New percentage: "+ val);
        scale.z = val;
        objt.transform.localScale = scale;
    }

}