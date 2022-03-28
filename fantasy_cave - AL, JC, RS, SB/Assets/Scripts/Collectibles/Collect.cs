using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour {
    void Update() { transform.Rotate(0, 0, 90 * Time.deltaTime); }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<playerMove>().points++;
            Destroy(gameObject);
            Debug.Log("Nope");
        }
    }
}
