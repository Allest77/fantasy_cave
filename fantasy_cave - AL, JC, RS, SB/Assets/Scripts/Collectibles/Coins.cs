using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour {
    public int coins;
    public Text coinCounter;

    void Start() {
        coins = 0;
        coinCounter.text = "Coins: " + coins.ToString();
    }

    void Update() {
        transform.Rotate(0, 0, 90 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if (other.name == "Humanoid Salamander") {
            other.GetComponent<playerMove>().coin++;
            coinCounter.text = "Coins: " + coins.ToString();
            Destroy(gameObject);
        }
    }
}
