using UnityEngine;
public class AutoRotateScreen : MonoBehaviour
{
    public Transform playerTransform;
    public float rotationSpeed = 20f;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerObject.transform;
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            float playerRotationY = playerTransform.eulerAngles.y;
            float targetRotationY = playerRotationY - 30f; // - 180f; // Add x-degree angle
            Vector3 targetEulerAngles = new Vector3(0f, -targetRotationY, 0f );
            Quaternion targetRotation = Quaternion.Euler(targetEulerAngles);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}