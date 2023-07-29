using System.Collections;
using UnityEngine;

/// <summary>
/// Handles when the player gets damage by 2D and 3D collisions and holds the current amount of health the player has.
/// Calls the Flickering method on <see cref="PlayerArtHandler"/> once damaged.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    #region Variables 
    [SerializeField] int health = 3;
    public int Health { get { return health; } set { health = value; } }


    [SerializeField] float invincibilityTime = 3;

    bool canTakeDamage = true;

    [SerializeField] PlayerArtHandler playerArtHandler;
    [SerializeField] PlayerPortalSkill playerPortalSkill;
    #endregion


    #region Methods 
    /// <summary>
    /// Subtracts health, activates invincibility and calls the Flickering method on the <see cref="PlayerArtHandler"/> 
    /// for a invincibility frames effect.
    /// </summary>
    /// <param name="amount"></param>
    void SubtractHealth(int amount)
    {
        if (!canTakeDamage || playerPortalSkill.InSkill) return; 

        Debug.Log("In subtract health");
        health -= amount;
        StartCoroutine(playerArtHandler.StartFlickering(invincibilityTime));
        StartCoroutine(EndInvinciblityCoroutine());
    }

    public IEnumerator EndInvinciblityCoroutine()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(invincibilityTime);
        canTakeDamage = true;
    }
    #endregion 

    #region Triggering
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Damage")
            SubtractHealth(1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Damage")
            SubtractHealth(1);
    }
    #endregion
}
