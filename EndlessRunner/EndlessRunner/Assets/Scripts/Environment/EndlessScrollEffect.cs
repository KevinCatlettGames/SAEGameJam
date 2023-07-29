using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessScrollEffect : MonoBehaviour
{
    public float speed;
    public bool goLeft; 
    public float despawnXPosition;
    public float spawnXPosition;

    private void Update()
    {
        if (goLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if(!goLeft)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if(transform.position.x <= despawnXPosition)
        {
            transform.position = new Vector2(spawnXPosition, transform.position.y);
        }
    }
}
