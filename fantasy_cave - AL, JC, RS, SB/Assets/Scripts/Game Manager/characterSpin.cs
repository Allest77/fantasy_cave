using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSpin : MonoBehaviour {
    public GameObject salamander;
    float rotationSpeed = 0.2f;
    void Update() {
        salamander.transform.Rotate(new Vector3(0, -rotationSpeed, 0));
    }
}