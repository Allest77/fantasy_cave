using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gameManager : MonoBehaviour {
    //Timer Variables (made public):
    public TextMeshProUGUI time;
    public float timer = 30;
    public float restartDelay = 1f;

    public Material material, material2;
    public float changeInterval = 0.01f;
    public bool isUsingPower = true; //This bool is to make sure the IEnumerator is only fired once and not every frame.

    //Game State Variables (Paused, Complete, etc.):
    bool gameHasEnded = false;
    public static bool GameIsPaused = false;

    //Pause Variables:
    public GameObject pauseMenuUI;
    public GameObject completeLevelUI;
    public LayerMask UILayer;

    //Reference to the player script:
    public playerMove player;

    //Power Up Variables: List of References.
    public BoxCollider yellowBlock;

    void Start() {
        Cursor.visible = true;
        player = GameObject.FindObjectOfType<playerMove>();
        yellowBlock = GetComponent<BoxCollider>();
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
        if (player.hasYellow) {
            yellowBlock.isTrigger = true;
            material = material2;
            if (isUsingPower) {
                StartCoroutine("PowerUpTime");
            }
        }
        else {
            material = material;
        }
    }

    IEnumerator PowerUpTime() {
        isUsingPower = false;
        yield return new WaitForSeconds(15);
        player.hasYellow = false;
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