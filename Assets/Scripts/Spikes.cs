using System;
using Scripts.Player;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private void OnCollisionEnter2D(Collision2D other)
    {
        playerHealth.TakeDamage(4);
    }
}
