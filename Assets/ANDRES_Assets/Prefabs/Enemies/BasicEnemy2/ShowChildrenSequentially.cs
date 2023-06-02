using UnityEngine;

public class ShowChildrenSequentially : MonoBehaviour {
    public float showDuration = 0.05f; // Duration in seconds for which each child is shown
    public float delayBetweenChildren = 0.1f; // Delay in seconds between showing each child
    private int currentIndex = 0;
    private float timer = 0f;

    private void Start() {
        HideAllChildren();
    }

    private void Update() {
        timer += Time.deltaTime;

        if (timer >= showDuration) {
            HideCurrentChild();
            ShowNextChild();
            timer = 0f;
        }
    }

    private void HideAllChildren() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }
    }

    private void HideCurrentChild() {
        Transform childToHide = transform.GetChild(currentIndex);
        childToHide.gameObject.SetActive(false);
    }

    private void ShowNextChild() {
        currentIndex++;
        if (currentIndex >= transform.childCount) {
            currentIndex = 0;
        }

        Transform childToShow = transform.GetChild(currentIndex);
        childToShow.gameObject.SetActive(true);
    }
}
