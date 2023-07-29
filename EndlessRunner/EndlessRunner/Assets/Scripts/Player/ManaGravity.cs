using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaGravity : MonoBehaviour
{
    private Rigidbody rb;
    private float chaseSpeed = 1.0f;
    [SerializeField] private float accelerationFactor = 1.1f;
    private Transform targetPlayer = null;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || targetPlayer != null) return;
        targetPlayer = other.transform;
        chaseSpeed = GameManager.Instance.LevelScrollSpeed * 1.5f;
        GetComponentInParent<BasicHorizontalMovement>().enabled = false;
        
        Debug.Log("Player hit trigger gravity trigger");
    }

    private void Update()
    {
        if (targetPlayer == null) return;
        
         transform.parent.Translate((targetPlayer.position - transform.position).normalized * (chaseSpeed * Time.deltaTime));
         chaseSpeed += chaseSpeed * accelerationFactor * Time.deltaTime;
    }
}
