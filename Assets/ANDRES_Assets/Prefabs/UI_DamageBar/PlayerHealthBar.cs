using UnityEngine;

public class PlayerHealthBar : MonoBehaviour {
    public static PlayerHealthBar THIS;
    public int currentHealthValue = 50;
    private GameObject objt;
    Vector3 scale;

    private void Awake() {
        if (THIS == null) {// SINGLETON
            THIS = this;
            GameManager.THIS.playerData.health = 90;
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        objt = transform.Find("PercentageBarSide/healthBar").gameObject;
        currentHealthValue = GameManager.THIS.playerData.health;
        Vector3 scale = objt.transform.localScale;
        UpdateBarLength();
    }

    private void UpdateBarLength() {
        float val = calcScale30fromPercentage(currentHealthValue);
        Debug.Log("[Bar] New percentage: " + currentHealthValue + "; scale.z: " + val);
        scale.z = val;
        scale.y = 1; // 6 hours of work to understand that this is mandatory! Fuck!
        scale.x = 1; // 6 hours of work to understand that this is mandatory!
        objt.transform.localScale = scale;
    }

    public void refreshBar() {
        currentHealthValue = GameManager.THIS.playerData.health;
        UpdateBarLength();
    }

    public float calcScale30fromPercentage(int percentage) {
        return percentage * 30f / 100f; // 30f is the length of the bar, using floating-point division
    }
}