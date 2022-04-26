using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapOut : MonoBehaviour {
    
    //Get reference to player.
    public playerMove player;

    //Use the yellow block to affect see thru platforms objs.
    public BoxCollider yellowBlock;
    public Material[] materials;
    public float changeInterval = 0.01f;

    private Renderer rend;

    private void Awake() {
        player = GameObject.FindObjectOfType<playerMove>();
    }

    void Start() {
        yellowBlock = GetComponent<BoxCollider>();

        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }
    void Update() {
        if (player.hasYellow) {
            yellowBlock.isTrigger = true;
            Debug.Log("wtf");
        }
    }
}
