using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followingPlayer : MonoBehaviour {
    //Publics
    public float smoothSpeed = 0.15f, smooth = 0.95f;
    public playerMove player;

    //Privates
    private Transform target;
    private Vector3 offset;

    void Start() {
        player.rb = player.GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
    }

    void FixedUpdate() {
        Vector3 desiredPosition = transform.position = target.position + offset;
        player.rb.MovePosition(transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed));
    }
}
