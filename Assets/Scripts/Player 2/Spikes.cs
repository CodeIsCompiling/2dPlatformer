using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Player_2
{
    public class Spikes : MonoBehaviour
    {
        [SerializeField] private HealthSystem healthSystem;
        
        private void OnCollisionStay2D(Collision2D other)
        {
            healthSystem.TakeDamage(10);
        }
    }
}