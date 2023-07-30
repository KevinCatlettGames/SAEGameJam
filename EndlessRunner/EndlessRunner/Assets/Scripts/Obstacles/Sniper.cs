using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public SniperLaser SniperLaser;
    private float timer;

    public AudioSource audioS;
    public AudioClip audioC;
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
        if(timer > 4)
        {
            Vector3 vector3 = new Vector3(Random.Range(-90, 90), Random.Range(20, 90));
            SniperLaser temp = Instantiate(SniperLaser, gameObject.transform.position, Quaternion.LookRotation(vector3));
            audioS.PlayOneShot(audioC);
            temp.parent = this;
            timer = Random.Range(0, 3);
        }
    }
    private void Move()
    {
        gameObject.transform.Translate(Vector3.left  * Time.deltaTime);
    }
}
