using UnityEngine;

// Moves to the left or right depending on the given values. 
public class BasicHorizontalMovement : MonoBehaviour
{
    [SerializeField] bool goLeft = true;
    public float additionalSpeed; 
    // Update is called once per frame
    void Update()
    {
        if (goLeft)
        {
            transform.Translate(Vector2.left * (additionalSpeed + GameManager.Instance.LevelScrollSpeed) * Time.deltaTime);
        }
        else if (!goLeft)
        {
            transform.Translate(Vector2.right * (additionalSpeed + GameManager.Instance.LevelScrollSpeed) * Time.deltaTime);
        }
    }
}
