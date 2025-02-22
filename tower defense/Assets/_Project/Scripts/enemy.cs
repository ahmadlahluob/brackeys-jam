using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemy : MonoBehaviour
{
    
    
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float damage = 10f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("target"))
            DoDamage();
    }

    void DoDamage()
    {
        PlayerHealth.Instance.TakeDamage(damage);
    }
}
