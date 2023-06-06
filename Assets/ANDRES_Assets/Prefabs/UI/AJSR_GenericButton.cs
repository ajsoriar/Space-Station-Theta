using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AJSR_GenericButton : MonoBehaviour
{
    public string ButtonText;
    public TextMesh textMesh;
    public Transform cube;

    // Start is called before the first frame update
    void Start() {
        // Set the text of the textMesh
        textMesh.text = ButtonText;

        // Get the Renderer component of the TextMesh
        Renderer textRenderer = textMesh.GetComponent<Renderer>();

        // Get the bounds of the rendered text
        Bounds textBounds = textRenderer.bounds;

        // Get the width of the text bounds
        float textWidth = textBounds.size.x;

        // Set the scale of the cube to match the width of the text
        Vector3 cubeScale = cube.localScale;
        cubeScale.x = textWidth;
        cube.localScale = cubeScale;
    }

}
