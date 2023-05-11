using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AJSR_ChangeCamera : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Debug.Log("Camera change!");

            if (camera1.enabled)
            {
                camera1.enabled = false;
                camera2.enabled = true;
            }
            else
            {
                camera1.enabled = true;
                camera2.enabled = false;
            }

        }

    }
}
