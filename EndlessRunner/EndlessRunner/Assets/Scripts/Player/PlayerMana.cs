using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public int mana;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Mana")
        {
            AddMana(1);
        }
    }

    public void AddMana(int amount)
    {
        mana += amount;
    }

    public void SubtractMana(int amount)
    {
        mana -= amount; 
    }
}
