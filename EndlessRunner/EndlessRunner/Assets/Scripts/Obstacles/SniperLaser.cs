using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SocialPlatforms;

public class SniperLaser : MonoBehaviour
{
    [HideInInspector] public Sniper parent;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        timer += Time.deltaTime;
        if (timer > 2)
        {
            Destroy(gameObject);
        }
    }
    private void Move()
    {
        if(parent != null)
        {
            transform.position = parent.gameObject.transform.position;
        }
    }

}
