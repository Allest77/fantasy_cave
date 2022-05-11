using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    //Variables for Player Controls
    public float speed = 7.5f, jumpHeight = 10.8f, jumpForce = 10.5f, jumpApex = 10.0f, gravityMod = 2.0f, fallSpeed;
    float currentVelocity, desiredVelocity;
    const float MovementPerSecond = 2.0f; //The currentVelocity will move to the desiredVelocity by this rate when called.
    bool facingRight = true;
    public AudioSource jumping;

    //Booleans: ground check & power ups.
    public bool isGrounded = true;
    public bool hasYellow = false;
    public List<GameObject> listOfPowerups;

    //Components to find.
    public Rigidbody rb;
    BoxCollider player;
    public Animator anim;

    //Vector3 Gravity Variables: Multiplies the player's fall speed when detecting a falling state.
    public Vector3 gravity;
    public Vector3 fastFall;

    //Collectible
    public float points;
    public int coin;
    public Coins coinCounterText;

    void Start() {
        //Need player's rigidbody
        rb = GetComponent<Rigidbody>();

        //Match the two gravitys, so they don't impact the player at the same time.
        currentVelocity = gravity.y;
        desiredVelocity = currentVelocity;
        anim = GetComponent<Animator>();
        coin = 0;
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
        anim.SetFloat("isWalking", hInput);
        rb.transform.position = rb.transform.position + new Vector3(hInput * speed * Time.deltaTime, 0, 0);
        Debug.Log("POSITIONING");

        //Flip the character's animation:
        if (hInput < 0 && facingRight) {
            Flip();
        }
        else if (hInput > 0 && !facingRight) {
            Flip();
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            anim.SetBool("isJumping", true);
            jumping.Play();
            rb.velocity = new Vector3(0.0f, rb.velocity.y, 0.0f);
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            ProcessMovement();
            if (fallSpeed < 0)
            {
                anim.SetBool("isFalling", true);
            }
        }

        //Attack
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("isAttacking", true);
            Debug.Log("INSERT ATTACK HERE");
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    void Flip() {
        facingRight = !facingRight; //if facing right is true, it will be false.
        transform.Rotate(0f, 180f, 0f);
    }

    //Ground Check Method
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
    }

    //Obtain Power Up
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Yellow")) {
            other.gameObject.SetActive(false);
            hasYellow = true;
        }

        if (other.gameObject.tag == "coins")
        {
            coin = coin + 1;
            coinCounterText.coinCounter.text = "Coins: " + coin.ToString();
        }
    }
}
