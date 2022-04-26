using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathTrigger : MonoBehaviour {
    public int respawn;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Destroy(gameObject);
            Debug.Log("GAAAAAME, OVVVVEEERRR.. WWWEEEOOOOOoo-...");
            SceneManager.LoadScene(respawn);
        }
    }
}
