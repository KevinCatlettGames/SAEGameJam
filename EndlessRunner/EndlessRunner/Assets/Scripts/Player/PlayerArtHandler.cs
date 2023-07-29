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

    #region Flickering
    public bool isFlickering;
    float flickerStateDuration = .2f;
    float currentFlickerStateDuration;
    #endregion

    private void Awake()
    {
        // TODO Change when which art is active depending on the currently loaded scene. (3D or 2D Art).
        activeObject = spriteObject;

        currentFlickerStateDuration = flickerStateDuration;
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
}
