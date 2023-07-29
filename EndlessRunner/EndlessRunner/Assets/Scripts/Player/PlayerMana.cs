using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Holds the current mana the player has and handles changes of the mana amount. 
/// </summary>
public class PlayerMana : MonoBehaviour
{
    [SerializeField] int mana = 50;

    [SerializeField] Slider manaSlider;
    public int Mana { get { return mana; } }

    #region Methods 
    private void Start()
    {
        if (manaSlider)
        {
            manaSlider.maxValue = mana;
            manaSlider.value = float.MaxValue;
        }
    }
    public void AddMana(int amount)
    {
        mana += amount;
        UpdateSlider();
    }
    public void SubtractMana(int amount)
    {
        mana -= amount;
        UpdateSlider();
    }

    void UpdateSlider()
    {
        manaSlider.value = mana;
    }
    #endregion

    #region Triggering
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Mana")
        {
            AddMana(1);
            Destroy(collision.gameObject);
        }
    }

    
    #endregion
}
