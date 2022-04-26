using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialChange : MonoBehaviour {
    //NEEDS AN INDICTAOR
    public playerMove player;
    public Renderer render;
    public Material material, material2;

    void Start() {
        player = GameObject.FindObjectOfType<playerMove>();
        render = GetComponent<Renderer>();
    }

    void Update() {
        if (player.hasYellow) {
            render.material = material2;
        }
        else
        {
            render.material = material;
        }
    }
}