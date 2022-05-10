using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicScript : MonoBehaviour {
    public static musicScript bgInstance;
    private void Awake() {
        if (bgInstance != null && bgInstance != this) {
            Destroy(this.gameObject);
            return;
        }

        bgInstance = this;
        DontDestroyOnLoad(this);
    }
}
