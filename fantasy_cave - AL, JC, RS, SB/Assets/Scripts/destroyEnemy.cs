using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEnemy : MonoBehaviour {

    public BoxCollider enemyWeakPoint;
    public AudioSource enemyHit;

    void Start() {
        enemyWeakPoint = GetComponent<BoxCollider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyHit.Play();
            Destroy(collision.gameObject);
        }
    }

}
