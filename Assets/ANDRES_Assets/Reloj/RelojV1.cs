using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RelojV1 : MonoBehaviour
{
    public float tiempo, limiteTiempo;
    int contador, currentTime;
    String hh, mm, ss;
    int hh_deg, mm_deg, ss_deg;

    // Start is called before the first frame update
    void Start()
    {
        tiempo = 0;
        limiteTiempo = 1;
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (tiempo < limiteTiempo)
        {
            tiempo += Time.deltaTime;
        }
        else
        {
            contador++;
            tiempo = 0;
            //Debug.Log("Otro segundo mas!");
            MoveClock();
        }
    }

    void MoveClock()
    {

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

        GameObject ui_hh = GameObject.Find("Hours");
        ui_hh.transform.eulerAngles = new Vector3(0, 0, hh_deg);

        GameObject ui_mm = GameObject.Find("Minutes");
        ui_mm.transform.eulerAngles = new Vector3(0, 0, mm_deg);

        GameObject ui_ss = GameObject.Find("Seconds");
        ui_ss.transform.eulerAngles = new Vector3(0, 0, ss_deg);
    }

    String GetCurrentTime()
    {
        return DateTime.Now.ToString("HH:mm:ss");
    }

    String GetHours()
    {
        return DateTime.Now.ToString("HH");
    }

    String GetMinutes()
    {
        return DateTime.Now.ToString("mm");
    }

    String GetSeconds()
    {
        return DateTime.Now.ToString("ss");
    }
}


