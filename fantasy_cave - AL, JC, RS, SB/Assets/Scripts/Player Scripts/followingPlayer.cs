using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followingPlayer : MonoBehaviour {
    //Publics
    public float smoothSpeed = 0.15f;
    public playerMove player;
    public Vector3 offset;

    //How much to delay the camera following the player.
    [Range(1, 10)]
    public float smoothFactor;

    //Privates
    private Transform target;

    void Start() {
        player.rb = player.GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
    }

    private void LateUpdate() {
        Follow();
    }

    void Follow() {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
