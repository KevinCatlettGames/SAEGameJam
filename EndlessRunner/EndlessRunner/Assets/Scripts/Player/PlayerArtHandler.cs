using System.Collections;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the currently active player art (if 3D or 2D). 
/// Holds a public method that activates and deactivates a flickering effect. 
/// </summary>
public class PlayerArtHandler : MonoBehaviour
{
    public GameObject modelObject;
    public GameObject modelObjectModelParentOne;
    public GameObject modelObjectModelParentTwo;

    public GameObject spriteObject;

    public GameObject activeObject;


    public GameObject futureModel;
    public GameObject futureModelParent;
    public int twoDIndex = 3;
    public int threeDIndex;
    public int futureIndex;
    #region Flickering
    public bool isFlickering;
    float flickerStateDuration = .2f;
    float currentFlickerStateDuration;
    #endregion

    private void Awake()
    {

        SceneManager.sceneLoaded += SceneLoadedEvent;

        // TODO Change when which art is active depending on the currently loaded scene. (3D or 2D Art).
        SceneLoadedEvent(SceneManager.GetActiveScene(), LoadSceneMode.Single);

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
            if (activeObject == spriteObject)
            {
                activeObject.GetComponent<SpriteRenderer>().enabled = !activeObject.GetComponent<SpriteRenderer>().enabled;
            }
            else if (activeObject == modelObject)
            {
                modelObjectModelParentOne.SetActive(!modelObjectModelParentOne.activeSelf);
                modelObjectModelParentTwo.SetActive(!modelObjectModelParentTwo.activeSelf);
            }
            else if (activeObject == futureModel)
            {
                futureModelParent.SetActive(!futureModelParent.activeSelf);
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
        if (SceneManager.GetActiveScene().buildIndex == 1) return;

        if (SceneManager.GetActiveScene().buildIndex == twoDIndex)
        {
            ActivateSprite();
            return;
        }
        else if (SceneManager.GetActiveScene().buildIndex == threeDIndex)
        {
            Activate3DModel();
        }
        else if (SceneManager.GetActiveScene().buildIndex == futureIndex)
        {
            ActivateFutureModel();
        }
    }

    void ActivateSprite()
    {
        if (activeObject == spriteObject) return;

        Debug.Log("Activating sprite, deactivating model");
        if (activeObject)
            spriteObject.GetComponent<PlayerHealth>().Health = activeObject.GetComponent<PlayerHealth>().Health;

        activeObject = spriteObject;
        spriteObject.SetActive(true);
        modelObject.SetActive(false);
        futureModel.SetActive(false);

    }

    void Activate3DModel()
    {
        if (activeObject == modelObject) return;

        Debug.Log("Activating model, deactivating sprite");
        if (activeObject)
            modelObject.GetComponent<PlayerHealth>().Health = activeObject.GetComponent<PlayerHealth>().Health;

        activeObject = modelObject;
        activeObject.SetActive(true);
        spriteObject.SetActive(false);
        futureModel.SetActive(false);
        modelObjectModelParentOne.SetActive(true);
        modelObjectModelParentTwo.SetActive(true);
    }

    void ActivateFutureModel()
    {
        if (activeObject == futureModel) return;

        Debug.Log("Activating future model, deactivating sprite and 3dmodel");
        if (activeObject)
        {
            futureModel.GetComponent<PlayerHealth>().Health = activeObject.GetComponent<PlayerHealth>().Health;
        }
        activeObject = futureModel;
        activeObject.SetActive(true);
        spriteObject.SetActive(false);
        modelObject.SetActive(false);
        futureModelParent.SetActive(true);
    }

    public void DoReset()
    {
        spriteObject.GetComponent<SpriteRenderer>().enabled = true;
        isFlickering = false; 

        modelObjectModelParentOne.SetActive(true);
        modelObjectModelParentTwo.SetActive(true);
        futureModelParent.SetActive(true);
        flickerStateDuration = currentFlickerStateDuration;
    }
}

