using UnityEngine;

namespace Scripts.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public void TakeDamage(int damage)
        {
            CurrentHealth -= (damage);
            Debug.Log(CurrentHealth);
        }
        
        public int MaxHealth = 100;
        public int CurrentHealth = 100;
    }
}