using System;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent<PlayerHealth>(out PlayerHealth health))
        {
            health.Damage(1);
        }
    }
}
