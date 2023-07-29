using UnityEngine;

/// <summary>
/// Holds the current mana the player has and handles changes of the mana amount. 
/// </summary>
public class PlayerMana : MonoBehaviour
{
    [SerializeField] int mana;
    public int Mana { get { return mana; } }

    #region Methods 
    public void AddMana(int amount)
    {
        mana += amount;

    }
    public void SubtractMana(int amount)
    {
        mana -= amount; 
    }
    #endregion

    #region Triggering
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Mana")
        {
            AddMana(1);
        }
    }
    #endregion
}
