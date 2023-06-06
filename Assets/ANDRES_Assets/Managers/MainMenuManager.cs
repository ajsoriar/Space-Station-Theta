using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager THIS;

    private void Awake() {
        THIS = this;
    }

    // Start is called before the first frame update
    void Start() {
        MainMenuManager.THIS.DisableObject("2_Options");
        MainMenuManager.THIS.DisableObject("3_About");
        MainMenuManager.THIS.EnableObject("1_Main_Menu");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update() {
        
    }
    public void DisableObject(string objectName) {
        Debug.Log("[Btn] DisableObject, objectName: " + objectName);
        GameObject obj = transform.Find(objectName).gameObject;
        if (obj != null) {
            obj.SetActive(false);
        }
    }
    public void EnableObject(string objectName) {
        Debug.Log("[Btn] EnableObject, objectName: " + objectName);
        GameObject obj = transform.Find(objectName).gameObject;
        if (obj != null) {
            obj.SetActive(true);
        }
    }
}
