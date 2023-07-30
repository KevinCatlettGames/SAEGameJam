using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Holds the current mana the player has and handles changes of the mana amount. 
/// </summary>
public class PlayerMana : MonoBehaviour
{
    [SerializeField] int mana = 0;

    [SerializeField] Slider manaSlider;
    public int Mana { get { return mana; } }

    public int manaScore; 

    #region Methods 
    private void Start()
    {
        if (manaSlider)
        {
            manaSlider.maxValue = 300;
            manaSlider.value = 0;
        }
    }
    public void AddMana(int amount)
    {
        manaScore += 1;
        if (mana <= 299)
        {
            mana += amount;
            UpdateSlider();
        }
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
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        }
    }

    public void ResetScore()
    {
        manaScore = 0;
        mana = 0;
        UpdateSlider();
    }

    
    #endregion
}
