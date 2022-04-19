using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("GAAAAAME, OVVVVEEERRR.. WWWEEEOOOOOoo-...");
            StartCoroutine("Respawn");
        }
    }

    IEnumerator Respawn() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Level");
    }
}
