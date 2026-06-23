using System;
using UnityEngine;

public class CarCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("item"))
        {
            Debug.Log("Item collected");
            Destroy(obj.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.collider.CompareTag("wall"))
        {
            Debug.Log("Collided with wall");
        }
        
        if (obj.collider.CompareTag("enemy"))
        {
            Debug.Log("Collided with enemy");
        }
    }
}
