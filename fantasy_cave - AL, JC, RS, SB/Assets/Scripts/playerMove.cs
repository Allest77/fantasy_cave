using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {
    //Variables for Player Controls
    public float speed = 7.5f, jumpHeight = 10.8f, jumpForce = 10.5f, jumpApex = 10.0f, gravityMod = 2.0f;
    float currentVelocity, desiredVelocity;
    const float MovementPerSecond = 2.0f; //The currentVelocity will move to the desiredVelocity by this rate when called.

    //Booleans: ground check & power ups.
    public bool isGrounded = true;
    public bool hasYellow = false;

    //Components to find.
    public Rigidbody rb;
    BoxCollider player;
    public Animator anim;

    //Vector3 Gravity Variables: Multiplies the player's fall speed when detecting a falling state.
    public Vector3 gravity;
    public Vector3 fastFall;

    void Start() {
        //Need player's rigidbody
        rb = GetComponent<Rigidbody>();
        
        //Match the two gravitys, so they don't impact the player at the same time.
        currentVelocity = gravity.y;
        desiredVelocity = currentVelocity;
        //anim = GetComponent<Animator>();
    }

    void ProcessMovement() {
        // Move from currentVelocity to desiredVelocity in real-time. Smooth outcome.
        currentVelocity = Mathf.MoveTowards(
            currentVelocity,
            desiredVelocity,
            MovementPerSecond * Time.deltaTime);
    }
    void Update() {
        //Movement
        float hInput = Input.GetAxis("Horizontal");
        //anim.SetFloat("isWalking", hInput);
        rb.transform.position = rb.transform.position + new Vector3(hInput * speed * Time.deltaTime, 0, 0);
        Debug.Log("POSITIONING");

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            isGrounded = false;
            //anim.SetBool("isJumping", true);
            rb.velocity = new Vector3(0.0f, rb.velocity.y, 0.0f);
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            ProcessMovement();
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
