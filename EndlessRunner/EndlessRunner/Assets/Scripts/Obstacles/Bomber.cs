using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    public GameObject tacticalMicrowave;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2.5)
        {
            Instantiate(tacticalMicrowave, gameObject.transform.position, Quaternion.identity);
            timer = Random.Range(0, 2);
        }
        Move();
    }
    private void Move()
    {
        gameObject.transform.Translate(Vector3.right * -2 * Time.deltaTime);

    }
}
