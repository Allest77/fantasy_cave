using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gameManager : MonoBehaviour {
    //- Timer Variables (made public) -
    public TextMeshProUGUI time;
    public float timer = 120f;
    public float restartDelay = 1f;

    public Material material, material2;
    public float changeInterval = 0.01f;
    public bool isUsingPower = true; //make sure the IEnumerator is only fired once and not every frame.

    //- Game State Variables (Paused, Complete, etc.) -
    bool gameHasEnded = false;
    public static bool GameIsPaused = false;
    private bool disablePause;
    private bool secret;

    //- Pause Variables -
    public GameObject pauseMenuUI;
    public GameObject completeLevelUI;
    public LayerMask UILayer;

    //- Reference to player script -
    public playerMove player;

    //- Power Up Variables: List of References -
    public BoxCollider yellowBlock;

    //- Score Display -
    public TextMeshProUGUI scoreText, highScoreText;
    int score = 0, highscore = 0;

    //Reference to coins script.
    public Coins coins;

    //- Awake is for when the player collides with something, add it to the score -
    private void Awake()
    {
        
    }

    void Start() {
        Cursor.visible = true;
        player = GameObject.FindObjectOfType<playerMove>();
        yellowBlock = GetComponent<BoxCollider>();
        disablePause = false;
        secret = false;
    }

    void Update() {
        //- Timer updates per frame and displays it through text -
        timer -= Time.deltaTime;
        time.text = "" + timer.ToString("f2");

        if (Input.GetKeyDown(KeyCode.Escape) && disablePause == false) {
            if (GameIsPaused) {
                Resume(); //make a resume method
            }
            else {
                Paws(); //make a pause method
            }
        }

        //- If the player has the power up, change their material. -
        if (player.hasYellow) {
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

    public void ObjectComponentState(Collider other, bool state) {
        other.GetComponentInChildren<MonoBehaviour>(true).enabled = state;
        other.GetComponentInChildren<MonoBehaviour>(true).gameObject.SetActive(state);
        other.GetComponent<MonoBehaviour>().enabled = state;
    }

    public void AddPoint() {
        score += 100;
        scoreText.text = score.ToString() + " Score:";
    }

    //- Method when pressing Resume button. -
    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //- Method when pressing button. -
    public void Paws() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void BackToMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //- Method when pressing Quit button. -
    public void QuitGame() {
        Application.Quit();
    }

    //- Disable Pause UI. -
    public void CompleteLevel() {
        completeLevelUI.SetActive(true);
        if (!Input.GetKey(KeyCode.Escape))
        {
            disablePause = true;
        }
    }

    //- When the timer reaches 0, load Game Over Method. - 
    private void FixedUpdate() {
        if (timer < 0) {
            GameOver();
        }
    }

    void GameOver() {
        SceneManager.LoadScene("GameOver");
    }

    public void EndGame() {
        if (gameHasEnded == false) {
            gameHasEnded = true;
            Debug.Log("GAME OVER!");
            Invoke("Restart", restartDelay);
        }
    }

    public void HundredCoins() {
        if (coins.coins >= 100) {
            secret = true;
            CompleteLevel();
            EndGame();
        }
    }
}