using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using System.Diagnostics;
//using System.Diagnostics;

public class Reloj : MonoBehaviour
{
    public float tiempo, limiteTiempo;
    int contador, currentTime;
    String hh, 
        mm, 
        ss;

    int hh_deg, 
        mm_deg, 
        ss_deg;

    GameObject parentGameObject,
        ui_hh,
        ui_mm,
        ui_ss;
        
    // Start is called before the first frame update
    void Start() {
        tiempo = 0;
        limiteTiempo = 1;
        contador = 0;

        GameObject reloj = transform.parent.gameObject;
        ui_hh = reloj.transform.Find("Hours").gameObject;
        ui_mm = reloj.transform.Find("Minutes").gameObject;
        ui_ss = reloj.transform.Find("Seconds").gameObject;
        
        Debug.Log("[Reloj] name: " + reloj.name);
        Debug.Log("[Reloj] ui_hh.name: " + ui_hh.name);
        Debug.Log("[Reloj] ui_mm.name: " + ui_mm.name);
        Debug.Log("[Reloj] ui_ss.name: " + ui_ss.name);
    }

    // Update is called once per frame
    void Update() {

        if ( tiempo < limiteTiempo) {
            tiempo += Time.deltaTime;
        } else {
            //Debug.Log("[Reloj] Otro segundo mas!");
            contador++;
            tiempo = 0;
            MoveClock();
        }
    }

    void MoveClock() {

        hh = GetHours();
        mm = GetMinutes();
        ss = GetSeconds();

        //Debug.Log("CurrentTime: " + hh +":"+ mm +":"+ ss);

        hh_deg = 270 - (Int16.Parse(hh) * 30 - 90);
        mm_deg = 270 - (Int16.Parse(mm) * 6 - 90);
        ss_deg = 270 - (Int16.Parse(ss) * 6 - 90);

        // GameObject ui_hh = GameObject.Find("Hours");
        // ui_hh.transform.Rotate(0,0,hh_deg);

        // GameObject ui_mm = GameObject.Find("Minutes");
        // ui_mm.transform.Rotate(0,0,mm_deg);

        // GameObject ui_ss = GameObject.Find("Seconds");
        // ui_ss.transform.Rotate(0,0,ss_deg);

        /*
        ui_hh.transform.eulerAngles = new Vector3(0,0,hh_deg); // Rotate relative to the world.
        ui_mm.transform.eulerAngles = new Vector3(0,0,mm_deg);
        ui_ss.transform.eulerAngles = new Vector3(0,0,ss_deg);
        */

        ui_hh.transform.localEulerAngles = new Vector3(0, 0, hh_deg); // thanks ChatGPT: how to rotate an object by using transform.eulerAngles relative to the parent object and not to the world.
        ui_mm.transform.localEulerAngles = new Vector3(0, 0, mm_deg);
        ui_ss.transform.localEulerAngles = new Vector3(0, 0, ss_deg);
    }

    String GetCurrentTime() {
        return DateTime.Now.ToString("HH:mm:ss");
    }

    String GetHours() {
        return DateTime.Now.ToString("HH");
    }

    String GetMinutes() {
        return DateTime.Now.ToString("mm");
    }

    String GetSeconds() {
        return DateTime.Now.ToString("ss");
    }
}