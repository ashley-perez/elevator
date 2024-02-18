using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjects : MonoBehaviour
{
    private CentralCollisionManager collisionManager;

    private void Start()
    {
        collisionManager = FindObjectOfType<CentralCollisionManager>();
    }


    

    private void OnTriggerEnter(Collider other)
    {
        if (collisionManager != null)
        {
            collisionManager.HandleTriggerEnter(gameObject, other.gameObject);
        }
    }
}

