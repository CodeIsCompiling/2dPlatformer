using System;
using UnityEngine;

namespace Player_2
{
    public class HealthSystem : MonoBehaviour
    {
        public int currentHealth;
        public int maxHealth;
        public int temporaryHealth;
        public event Action<int> OnHealthChanged; 

        public void TakeDamage(int damage)
        {
            if (temporaryHealth > 0)
            {
                temporaryHealth -= damage;
            }

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
