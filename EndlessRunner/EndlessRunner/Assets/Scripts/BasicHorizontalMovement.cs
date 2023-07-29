using UnityEngine;

// Moves to the left or right depending on the given values. 
public class BasicHorizontalMovement : MonoBehaviour
{
    [SerializeField] bool goLeft = true;

    // Update is called once per frame
    void Update()
    {
        if (goLeft)
        {
            transform.Translate(Vector2.left * GameManager.Instance.LevelScrollSpeed * Time.deltaTime);
        }
        else if (!goLeft)
        {
            transform.Translate(Vector2.right * GameManager.Instance.LevelScrollSpeed * Time.deltaTime);
        }
    }
}
