using UnityEngine;

public class PlayerJump2 : MonoBehaviour {
    public float jumpForce = 5f;
    private bool isJumping = false;

    private Rigidbody playerRigidbody;

    private void Start() {
        // Get the Rigidbody component attached to the player object
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        // Check for jump input
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) {
            Jump();
        }
    }

    private void Jump() {
        // Apply the jump force to the player's Rigidbody
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // Set isJumping flag to true
        isJumping = true;

        SoundManager.THIS.PlaySound_Jump();
    }

    private void OnCollisionEnter(Collision collision) {
        // Check if the player has landed on the ground
        if (collision.gameObject.CompareTag("Ground")) {
            isJumping = false;
        }
    }
}