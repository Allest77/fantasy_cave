using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prologueScene : MonoBehaviour {
    [SerializeField]
    private float restartDelay = 6f;
    [SerializeField] 
    private string sceneNameToLoad;

    private float timeElapsed;

    private void Update() {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > restartDelay)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
