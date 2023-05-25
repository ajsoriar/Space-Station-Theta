using System.Collections;
using System.Collections.Generic;
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
        //GameManager.THIS.playerData.oxygen = 90;
        UpdateBarLength();
    }

    private void FixedUpdate() {
        //UpdateBarLength();
    }

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
    public float calcScale30fromPercentage(int percentage) {
        return percentage * 30 / 100; // 30 is the length of the bar.
    }

}