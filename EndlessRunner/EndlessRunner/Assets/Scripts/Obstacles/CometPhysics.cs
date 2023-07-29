using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class CometPhysics : MonoBehaviour, IObstacle
{
    public GameObject Boom;

    public LayerMask ground;
    public LayerMask player;

    public Rigidbody2D rb;

    public float speed;
    public float directionX = 0;
    //public float directionX = -5f;

    public float timer = 0;

    public bool useMethodWaitBeforeFall = true;
    public bool addForce = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 0f;
        rb.gravityScale = 0;
        directionX = Random.Range(-0.025f, 0.025f);
    }


    // Update is called once per frame
    void Update()
    {
        if (useMethodWaitBeforeFall)
        {
            WaitBeforeFall();
        }
        if (addForce)
        {
            Fall();

        }

    }
    private void FixedUpdate()
    {

    }
    void WaitBeforeFall()
    {
        if (timer <= 2.5f)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 2.5f)
        {
            rb.gravityScale = 1;

            useMethodWaitBeforeFall = false;
            addForce = true;
        }
    }

    void Fall()
    {
        rb.AddForce(Vector2.right * directionX, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.gameObject.tag == "Ground") 
        {
            Transform transform = rb.transform;
            Instantiate(Boom, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
