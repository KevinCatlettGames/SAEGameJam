using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static Vector3 playerStartPos; 
    #region SceneManagement

    public const int TransitionSceneIndex = 1; // Change this if portal scene index changes
    private AsyncOperation currentSceneLoadingOperation;
    public int CurrentOriginScene { get; private set; }
    public int CurrentTargetScene { get; private set; }

    #endregion

    #region LevelMovement

    public float LevelScrollSpeed { get; set; } = 2;

    #endregion
        
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);

        playerStartPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void TeleportToScene(int sceneIndex)
    {
        if (currentSceneLoadingOperation != null && !currentSceneLoadingOperation.isDone) return;

        CurrentOriginScene = SceneManager.GetActiveScene().buildIndex;
        CurrentTargetScene = sceneIndex;
        currentSceneLoadingOperation = SceneManager.LoadSceneAsync(TransitionSceneIndex);
        
        currentSceneLoadingOperation.completed += _ => { Debug.Log("Loaded Portal Scene"); /*SceneManager.UnloadSceneAsync(CurrentOriginScene);*/ };
    }

    public void RestartGame()
    {
        Cursor.visible = false;       
        SceneManager.LoadScene(2);
        GameObject.FindGameObjectWithTag("Player").transform.position = playerStartPos;
    }
}
