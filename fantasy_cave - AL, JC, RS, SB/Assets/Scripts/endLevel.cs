using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endLevel : MonoBehaviour {
    //End Level Condition Needed.
    public gameManager manageTheGame;

    //Cross this collider to trigger the END LEVEL, thing.
    void OnTriggerEnter() {
        manageTheGame.CompleteLevel();
        StartCoroutine("TakeMeBack");
    }

    IEnumerator TakeMeBack() {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");
    }
}
