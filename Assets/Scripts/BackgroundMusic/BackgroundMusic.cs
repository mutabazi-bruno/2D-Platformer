using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

    private static BackgroundMusic instance;

    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

void Update() {
    if (Input.GetKeyDown(KeyCode.M)) {
        GetComponent<AudioSource>().Play();
    }
}
} // class