using UnityEngine;

public class MatrixDisplay : MonoBehaviour {
    public GameObject cubePrefab;
    private GameObject[,] cubes;

    private void Start() {
        CreateMatrix();
    }

    private void CreateMatrix() {
        cubes = new GameObject[8, 8];

        float spacing = 0.12f; // Spacing between cubes
        Vector3 offset = new Vector3(-0.35f, 0.35f, 0f); // Offset to center the matrix

        for (int x = 0; x < 8; x++) {
            for (int y = 0; y < 8; y++) {
                Vector3 position = new Vector3(x * spacing, -y * spacing, 0f) + offset;
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity, transform);
                cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                cubes[x, y] = cube;
            }
        }
    }

    public void SetCubeColor(int x, int y, Color color) {
        if (IsValidIndex(x, y)) {
            cubes[x, y].GetComponent<Renderer>().material.color = color;
        }
    }

    private bool IsValidIndex(int x, int y) {
        return x >= 0 && x < 8 && y >= 0 && y < 8;
    }
}
