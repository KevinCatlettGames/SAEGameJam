using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTeleportCaller : MonoBehaviour
{
    [SerializeField] private float testTeleportDelay = 4.5f;
    

    // Update is called once per frame
    void Update()
    {
        if (testTeleportDelay <= 0)
        {
            GameManager.Instance.TeleportToScene(0);
        }
        
        testTeleportDelay -= Time.deltaTime;
    }
}
