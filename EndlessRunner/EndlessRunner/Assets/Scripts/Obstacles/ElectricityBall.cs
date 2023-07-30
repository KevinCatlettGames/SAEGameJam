using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityBall : MonoBehaviour
{
    private float time;
    public Transform transformCarPosition;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        time += Time.deltaTime;
        if (time > 1)
        {
            Destroy(gameObject);
        }
    }
    private void Move()
    {
        gameObject.transform.Translate(Vector3.right * -2 * Time.deltaTime);
    }
}
