using UnityEngine;

public class SpeedBoots : MonoBehaviour {
    // Start is called before the first frame update

    public int steps;
    public int velocity;

    private const int DEFAULT_STEPS = 100;
    private const int DEFAULT_VELOCITY = 4;

    void Start() {

        if (steps == 0) steps = DEFAULT_STEPS;
        if (velocity == 0) velocity = DEFAULT_VELOCITY;
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            SoundManager.THIS.PlaySound_GetCoin();
            gameObject.SetActive(false);
            GameManager.THIS.playerData.speedBootsSteps = steps;
            GameManager.THIS.playerData.speedBootsVelocity = velocity;
        }
    }

}
