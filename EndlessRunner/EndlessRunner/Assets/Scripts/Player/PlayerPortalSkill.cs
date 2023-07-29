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

    // The constant buildindex
    public const int prehistoricIndex = 2;
    public const int middleAgeIndex = 3;
    public const int futureIndex = 4;

    [SerializeField] GameObject LevelCanvas;
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
        if (Input.GetKeyDown(KeyCode.Q) && !inSkill)
        {
            // Handle skill duration
            inSkill = true;
            playerMana.SubtractMana(1);
            StartCoroutine(UnlockSkillUsageCoroutine());
            int nextIndex = 0;

            // Handle scene choosing 
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case prehistoricIndex:
                    nextIndex = futureIndex;
                    break;

                case middleAgeIndex:
                    nextIndex = prehistoricIndex;
                    break;

                case futureIndex:
                    nextIndex = middleAgeIndex;
                    break;

                default:
                    nextIndex = prehistoricIndex;
                    break;
            }
            GameManager.Instance.TeleportToScene(nextIndex);
        }

        // Go forward in time 
        else if (Input.GetKeyDown(KeyCode.E) && !inSkill)
        {
            // Handle Skill duration
            inSkill = true;
            playerMana.SubtractMana(1);
            StartCoroutine(UnlockSkillUsageCoroutine());

            // Handle scene choosing
            int nextIndex = 0;
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case prehistoricIndex:
                    nextIndex = middleAgeIndex;
                    break;

                case middleAgeIndex:
                    nextIndex = futureIndex;
                    break;

                case futureIndex:
                    nextIndex = prehistoricIndex;
                    break;

                default:
                    nextIndex = prehistoricIndex;
                    break;
            }
            GameManager.Instance.TeleportToScene(nextIndex);
        }
    }
}
