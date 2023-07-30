using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrocutioner : MonoBehaviour
{
    private float timer;
    public GameObject electricityObject;
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
        if (timer > 2.5f)
        {
            Instantiate(electricityObject, gameObject.transform.position, Quaternion.identity);
            timer = 0;
        }
    }
    private void Move()
    {
        gameObject.transform.Translate(Vector3.right * -2 * Time.deltaTime);
    }
}
