using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes a singleton out of the player and makes the gameobject not be destroyed when a scene in loaded. 
/// </summary>
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

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
    }

    // Update is called once per frame
    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
  
}
