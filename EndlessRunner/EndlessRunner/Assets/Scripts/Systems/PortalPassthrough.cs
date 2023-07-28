using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalPassthrough : MonoBehaviour
{
    [SerializeField]
    private float teleportDelay = 3.0f;

    // Update is called once per frame
    void Update()
    {
        if (teleportDelay <= 0)
        {
            int targetScene = GameManager.Instance.CurrentTargetScene;
            SceneManager.LoadSceneAsync(targetScene).completed += _ => { Debug.Log($"Loaded scene index {targetScene}"); };
        }
        teleportDelay -= Time.deltaTime;
    }
}
