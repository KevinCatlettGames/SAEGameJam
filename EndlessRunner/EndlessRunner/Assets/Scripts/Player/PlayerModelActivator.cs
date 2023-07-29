using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerModelActivator : MonoBehaviour
{

    public GameObject modelObject;
    public GameObject spriteObject;

    public GameObject activeObject; 
    private void Awake()
    {
        activeObject = spriteObject;
    }
}
