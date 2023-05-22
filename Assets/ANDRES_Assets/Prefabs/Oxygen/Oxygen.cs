using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Oxygen : MonoBehaviour
{

    public int oxygenLever = 50;

    void Start() {
        if (oxygenLever > 100){
            oxygenLever = 100;
        }else if (oxygenLever < 0) {
            oxygenLever = 0;
        }

        SetOxygenLevel(oxygenLever);
    }

    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            SoundManager.THIS.PlaySound_GetCoin();
            gameObject.SetActive(false);
            GameManager.THIS.playerData.oxygenBotleCount += 1;

            // Calculate and update the oxygen bar
        }
    }

    // Right from ChatGPT, LOL!
    // I need to set the z scale of O2 to a value of public int oxygenValue.
    // Inject the functionality in a function called setOxigenLevel.

    /*
    public void SetOxygenLevel(int oxygenValue) 
    {
        GameObject O2 = GameObject.Find("OxygenMeter");

        Vector3 scale = O2.transform.localScale;
        scale.z = oxygenValue;
        O2.transform.localScale = scale;
    }
    */

    // GameObject.Find("OxygenMeter"); is finding objects in all the scene.I need fo select the OxygenMeter included in the GameObject where the script was applied
    public void SetOxygenLevel(int oxygenValue)
    {
        GameObject O2 = transform.Find("OxygenMeter").gameObject;

        Vector3 scale = O2.transform.localScale;
        scale.z = oxygenValue;
        O2.transform.localScale = scale;
    }

}
