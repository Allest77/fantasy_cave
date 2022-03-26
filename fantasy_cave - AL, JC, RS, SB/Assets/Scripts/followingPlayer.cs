using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followingPlayer : MonoBehaviour {
    //Publics
    public Transform playerTarget;
    public float smoothSpeed = 0.15f;

    //Privates
    private Transform target;
    private Vector3 offset;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
    }

    void LateUpdate() {
        transform.LookAt(playerTarget);

        Vector3 desiredPosition = transform.position = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
