using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityBall : MonoBehaviour
{
    private float timer;
    public Transform transformCarPosition;
    public AudioSource audioS;
    public AudioClip audioC; 
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        audioS.PlayOneShot(audioC);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        timer += Time.deltaTime;
        if (timer > 1)
        {
            Destroy(gameObject);
        }
    }
    private void Move()
    {
        gameObject.transform.Translate(Vector3.right * -2 * Time.deltaTime);
    }
}
