using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;

public class AJSR_Inject_FBX : MonoBehaviour
{
    public GameObject targetObject;
    //public string fbxFilePath = "Assets/ANDRES_Assets/Models/arbol_model1_v2.FBX";
    string fbxFilePath = "https://www.subidote.com/unity/downloads/models/arbol_model1_v4.fbx";
    public Vector3 position = Vector3.zero;
    public Vector3 scale = Vector3.one;

    [System.Obsolete]
    void Start() {
        StartCoroutine(LoadFBXFile(fbxFilePath, targetObject, position, scale));
    }

    /*
    [System.Obsolete]
    IEnumerator LoadFBXFile(string fbxFilePath, GameObject targetObject, Vector3 position, Vector3 scale)
    {
        WWW www = new WWW(fbxFilePath);
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError("Failed to load FBX file: " + www.error);
            yield break;
        }

        GameObject loadedObject = Instantiate(www.assetBundle.mainAsset) as GameObject;
        loadedObject.transform.SetParent(targetObject.transform, false);
        loadedObject.transform.localPosition = position;
        loadedObject.transform.localScale = scale;

        www.assetBundle.Unload(false);
    }*/

    [System.Obsolete]
    IEnumerator LoadFBXFile(string fbxFilePath, GameObject targetObject, Vector3 position = default, Vector3 scale = default)
    {
        WWW www = new WWW(fbxFilePath);
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError("Failed to load FBX file: " + www.error);
            yield break;
        }

        AssetBundle assetBundle = www.assetBundle;
        GameObject loadedObject = Instantiate(assetBundle.mainAsset) as GameObject;
        loadedObject.transform.SetParent(targetObject.transform, false);
        loadedObject.transform.localPosition = position;
        loadedObject.transform.localScale = scale;

        assetBundle.Unload(false);
    }

}
