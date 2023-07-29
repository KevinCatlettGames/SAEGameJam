using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the currently active player art (if 3D or 2D). 
/// Holds a public method that activates and deactivates a flickering effect. 
/// </summary>
public class PlayerArtHandler : MonoBehaviour
{
    public GameObject modelObject;
    public GameObject spriteObject;

    public GameObject activeObject;

    public int twoDIndex = 3;
    public int[] threeDIndex; 
    #region Flickering
    public bool isFlickering;
    float flickerStateDuration = .2f;
    float currentFlickerStateDuration;
    #endregion

    private void Awake()
    {

        SceneManager.sceneLoaded += SceneLoadedEvent;

        // TODO Change when which art is active depending on the currently loaded scene. (3D or 2D Art).
        ActivateArt(spriteObject);

        currentFlickerStateDuration = flickerStateDuration;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SceneLoadedEvent; 
    }

    private void Update()
    {
        Flicker();
    }
    private void Flicker()
    {
        if (!isFlickering) return; 
        
        flickerStateDuration -= Time.deltaTime;
        
        if (flickerStateDuration <= 0)
        {
            flickerStateDuration = currentFlickerStateDuration;
            if (activeObject.GetComponent<SpriteRenderer>())
            {
                activeObject.GetComponent<SpriteRenderer>().enabled = !activeObject.GetComponent<SpriteRenderer>().enabled;
            }
            else if (activeObject.GetComponent<MeshRenderer>())
            {
                activeObject.GetComponent<MeshRenderer>().enabled = !activeObject.GetComponent<MeshRenderer>().enabled;
            }
        }       
    }

    public IEnumerator StartFlickering(float duration)
    {
        isFlickering = true; 
        yield return new WaitForSeconds(duration);
        isFlickering = false;

        // Makes sure the currently active objects art is definetly enables after flickering. 
        if (activeObject.GetComponent<SpriteRenderer>())
            activeObject.GetComponent<SpriteRenderer>().enabled = true;
        else if (activeObject.GetComponent<MeshRenderer>())
            activeObject.GetComponent<MeshRenderer>().enabled = true;
    }

    void SceneLoadedEvent(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (SceneManager.GetActiveScene().buildIndex == 2) return;

        if(SceneManager.GetActiveScene().buildIndex == twoDIndex)
        {
            ActivateArt(spriteObject);           
        }
        else
        {
            foreach(int index in threeDIndex)
            {
                if(SceneManager.GetActiveScene().buildIndex == index)
                {
                    ActivateArt(modelObject);

                }
            }
        }
    }

    void ActivateArt(GameObject objectToActivate)
    {
        if(objectToActivate == spriteObject && activeObject != objectToActivate)
        {
            Debug.Log("Activating sprite, deactivating model");
            spriteObject.GetComponent<PlayerHealth>().Health = modelObject.GetComponent<PlayerHealth>().Health;
            activeObject = objectToActivate;
            spriteObject.SetActive(true);
            modelObject.SetActive(false);
        }
        else if(objectToActivate == modelObject && activeObject != objectToActivate)
        {
            Debug.Log("Activating model, deactivating sprite");
            modelObject.GetComponent<PlayerHealth>().Health = spriteObject.GetComponent<PlayerHealth>().Health;
            activeObject = objectToActivate;
            objectToActivate.SetActive(true);
            spriteObject.SetActive(false);
        }
    }
}

