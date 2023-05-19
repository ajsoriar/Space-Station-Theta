using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndresHelpers
{
    public static Vector3 Vector3MinusFloatValue(Vector3 v, float f)
    {
        return new Vector3(v.x - f, v.y - f, v.z - f);
    }

    public static int MinusFive(int value)
    {
        return value - 5;
    }
    public void UpdateTextMesh(string textMeshName, string newText) // Thanks ChatGPT
    {
        GameObject gameObjectWithTextMesh = GameObject.Find(textMeshName);
        if (gameObjectWithTextMesh != null)
        {
            TextMesh textMeshComponent = gameObjectWithTextMesh.GetComponentInChildren<TextMesh>();
            if (textMeshComponent != null)
            {
                textMeshComponent.text = newText;
            }
            else
            {
                Debug.LogError("No TextMesh component found on game object: " + textMeshName);
            }
        }
        else
        {
            Debug.LogError("Could not find game object: " + textMeshName);
        }
    }

}