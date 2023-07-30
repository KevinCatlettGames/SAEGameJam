using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the calling and activation of portaling. 
/// </summary>
public class PlayerPortalSkill : MonoBehaviour
{
    #region Variables 
    PlayerMana playerMana;

    [SerializeField] bool inSkill;
    public bool InSkill { get { return inSkill; } }

    [SerializeField] float skillDuration = 3;

    [SerializeField] GameObject LevelCanvas;
    [SerializeField] GameObject portalObject;
    public AudioSource audioS;
    public AudioClip audioC;
    #endregion 

    private void Awake()
    {
        playerMana = GetComponent<PlayerMana>();    
    }
    // Update is called once per frame
    void Update()
    {
        ActivatePortal();         
    }

    IEnumerator UnlockSkillUsageCoroutine()
    {
        LevelCanvas.SetActive(false);
        yield return new WaitForSeconds(skillDuration);
        inSkill = false;
        LevelCanvas.SetActive(true);
    }

    private void ActivatePortal()
    {
        // Go back in time 
        if (Input.GetKeyDown(KeyCode.E) && !inSkill && playerMana.Mana >= 300)
        {
            // Handle skill duration
            inSkill = true;
            playerMana.SubtractMana(300);
            StartCoroutine(UnlockSkillUsageCoroutine());
            Instantiate(portalObject, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), Quaternion.identity);
            audioS.PlayOneShot(audioC);
        }     
    }
}
