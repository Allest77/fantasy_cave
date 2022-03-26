using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {
    //Variables for Player Controls
    public float speed = 7.5f, jumpHeight = 10.8f, jumpForce = 20, gravity = -20.0f, gravityMod = 2.0f;

    //Booleans: ground check & power ups.
    public bool isGrounded = true;
    public bool hasYellow = false;

    //Components to find.
    Rigidbody rb;
    BoxCollider player;
    public Animator anim;

    void Start() {
        //Need player's rigidbody
        rb = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
    }

    void Update() {
        //Movement
        float hInput = Input.GetAxis("Horizontal");
        //anim.SetFloat("isWalking", hInput);
        //float vInput = Input.GetAxis("Vertical");
        rb.transform.position = rb.transform.position + new Vector3(hInput * speed * Time.deltaTime, 0, 0);
        Debug.Log("POSITIONING");

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            isGrounded = false;
            //anim.SetBool("isJumping", true);
            rb.velocity = new Vector3(0.0f, rb.velocity.y, 0.0f);
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        //Attack
        if (Input.GetKeyDown(KeyCode.E)) {
            //anim.SetBool("isAttacking", true);
            Debug.Log("INSERT ATTACK HERE");
        }
        /*else {
            anim.SetBool("isAttacking", false);
        }*/
    }

    //Ground Check Method
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            //anim.SetBool("isJumping", false);
        }
    }
}
