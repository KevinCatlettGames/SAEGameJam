using UnityEngine;

// Moves to the left or right depending on the given values. 
public class BasicHorizontalMovement : MonoBehaviour
{
    [SerializeField] bool goLeft = true;
    [SerializeField] float speed = 2; 

    // Update is called once per frame
    void Update()
    {
        if (goLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (!goLeft)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
