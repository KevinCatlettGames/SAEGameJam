using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public float invincibilityTime = 3;
    public bool canTakeDamage = true;
    public PlayerModelActivator playerModelActivator;

    float invincibilityEffectSwitchDuration = .2f;
    float startInvinciblityEffectSwitchDuration;

    private void Awake()
    {
        startInvinciblityEffectSwitchDuration = invincibilityEffectSwitchDuration;
    }
    private void Update()
    {
        if(canTakeDamage == false)
        {
            invincibilityEffectSwitchDuration -= Time.deltaTime;
            if(invincibilityEffectSwitchDuration <= 0)
            {
                invincibilityEffectSwitchDuration = startInvinciblityEffectSwitchDuration;
                playerModelActivator.activeObject.SetActive(!playerModelActivator.activeObject.activeSelf);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Obstacle")
        {
            SubtractHealth(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            SubtractHealth(1);
        }
    }

    void SubtractHealth(int amount)
    {
        health -= amount;
        StartCoroutine(InvincibilityCoroutine(invincibilityTime));
    }

    public IEnumerator InvincibilityCoroutine(float duration)
    {
        canTakeDamage = false; 
        yield return new WaitForSeconds(duration);
        canTakeDamage = true;
        playerModelActivator.activeObject.SetActive(true);
    }
}
