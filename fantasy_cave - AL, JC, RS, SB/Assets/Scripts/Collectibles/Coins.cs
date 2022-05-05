using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour {
    int coins = 0;
    public Text coinCounter;

    void Update() { 
        transform.Rotate(0, 0, 90 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            coins += coins + 1;
            coinCounter.text = "Coins: " + coins.ToString();
            Destroy(gameObject);
            Debug.Log("Mon-e");
        }
    }
}
