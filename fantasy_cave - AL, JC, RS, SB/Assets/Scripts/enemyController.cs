using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    public Transform target;
    public BoxCollider hitpoint;
    public bool isGrounded;
    public Rigidbody rb;

    //Enemy speed.
    float enemySpeed = 4.2f;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    //Have the enemy home in on player.
    private void FixedUpdate() {
        var step = enemySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }
}