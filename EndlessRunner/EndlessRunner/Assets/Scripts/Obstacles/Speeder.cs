using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Speeder : MonoBehaviour
{
    private Transform transform;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(Vector3.right * -4 * Time.deltaTime);
        if (transform.position.y > playerTransform.position.y)
        {
            transform.position =new Vector2(transform.position.x, transform.position.y - Time.deltaTime);
        }
        else
        {
            transform.position =new Vector2(transform.position.x, transform.position.y + Time.deltaTime);

        }
    }
}
