using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortalSkill : MonoBehaviour
{

    PlayerMana playerMana;
    bool inSkill;
    public float skillDuration; 
    private void Awake()
    {
        playerMana = GetComponent<PlayerMana>();    
    }
    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.E) && !inSkill)
       {
            inSkill = true;
            playerMana.SubtractMana(1);
            StartCoroutine(DisableSkillCoroutine());
            // TODO Add skill functionality
       }
    }

    IEnumerator DisableSkillCoroutine()
    {
        yield return new WaitForSeconds(skillDuration);
        inSkill = false; 
    }
}
