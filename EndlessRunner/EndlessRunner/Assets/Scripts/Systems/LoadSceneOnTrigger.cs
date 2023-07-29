using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTrigger : MonoBehaviour
{
    [SerializeField] int sceneToLoad;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            SceneManager.LoadScene(sceneToLoad);
          
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            SceneManager.LoadScene(sceneToLoad);

    }
}
