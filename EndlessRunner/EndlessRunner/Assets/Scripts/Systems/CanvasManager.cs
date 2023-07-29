using UnityEngine;

/// <summary>
/// Makes the canvas a singleton that stays over scene loading. 
/// </summary>
public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance; 

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