using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {
    //Timer Variables (made public).
    public Text time;
    public float timer = 30;
    public float restartDelay = 1f;

    bool gameHasEnded = false;
    public static bool GameIsPaused = false;

    //Pause Variables (made public).
    public GameObject pauseMenuUI;
    public GameObject completeLevelUI;
    public LayerMask UILayer;

    //Change Material (For Phasing Platform Material)
    public playerMove player;
    //public Renderer render;
    public Material material, material2;

    void Start() {
        Cursor.visible = true;
        player = GameObject.FindObjectOfType<playerMove>();
        //render = GetComponent<Renderer>();
    }

    void Update() {
        //Timer updates per frame and displays it through text.
        timer -= Time.deltaTime;
        time.text = "" + timer.ToString("f2");

        //Press the escape key to pause the game.
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume(); //make a resume method
            }
            else {
                Paws(); //make a pause method
            }
        }

        //If the player has the power up, change their material.
        /*if (player.hasYellow) {
            //render.material = material2;
        }
        else {
            //render.material = material;
        }*/
    }

    //Method when pressing button.
    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //Method when pressing button.
    public void Paws() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //Method when pressing button.
    public void QuitGame() {
        Application.Quit();
    }

    public void CompleteLevel() {
        completeLevelUI.SetActive(true);
    }

    public void EndGame() {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER!");
            Invoke("Restart", restartDelay);
        }
    }
}