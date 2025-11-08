using System;
using Unity.Collections;
using UnityEngine;

namespace Player_2
{
    public class HealthSystem : MonoBehaviour
    {
        public int maxHealth = 100;
        public int currentHealth;
        public int temporaryHealth;
        public float invincibilityCooldown = 3f;
        public event Action<int> OnHealthChanged;
        public bool IsInvincible => _lastTimeDamaged < invincibilityCooldown;
        private float _lastTimeDamaged;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        private void Update()
        {
            _lastTimeDamaged += Time.deltaTime;
        }

        public void TakeDamage(int damage)
        {
            if (IsInvincible)
            {
                return;
            }
            
            temporaryHealth -= damage;
            _lastTimeDamaged = 0;
            
            if (temporaryHealth < 0)
            {
                currentHealth += temporaryHealth;
                temporaryHealth = 0;
            }
            
            if (currentHealth < 0)
            {
                // Player Died
                currentHealth = 0;
            }
            OnHealthChanged?.Invoke(currentHealth);
        }

        public void Heal(int heal)
        {
            currentHealth += heal;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            OnHealthChanged?.Invoke(currentHealth);
        }

        public void SetHealth(int health)
        {
            currentHealth = health;
            OnHealthChanged?.Invoke(currentHealth);
        }

        public void AddMaxHp(int maxHp)
        {
            maxHealth += maxHp; 
            OnHealthChanged?.Invoke(maxHealth);
        }

        public void AddTemporaryHp(int amount)
        {
            temporaryHealth += amount;
        }
        
    }
}
