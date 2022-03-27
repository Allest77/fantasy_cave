using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityModifier : MonoBehaviour {
    public float gravityMultiplier = 3.5f, shortHop = 2f;
    public playerMove player;

    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector3.up * Physics.gravity.y * (gravityMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            rb.velocity += Vector3.up * Physics.gravity.y * (shortHop - 1) * Time.deltaTime;
        }
    }
}
