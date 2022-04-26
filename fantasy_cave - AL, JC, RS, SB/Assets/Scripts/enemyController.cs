using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{ 
    public Transform target;
    public BoxCollider hitpoint;

    //Enemy speed.
    float enemySpeed = 4.2f;

    //Have the enemy home in on player.
    private void Update() {
        var step = enemySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    //Jump on the enemy to destroy it.
    public void OnTriggerEnter(Collider hitpoint) {
        Destroy(hitpoint.gameObject);
    }
}