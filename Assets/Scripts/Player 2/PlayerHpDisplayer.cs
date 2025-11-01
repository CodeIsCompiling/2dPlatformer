using UnityEngine;
using UnityEngine.UI;

namespace Player_2
{
    public class PlayerHpDisplayer : MonoBehaviour
    {
        [SerializeField] private HealthSystem healthSystem;
        [SerializeField] private Image hpBar;

        private void OnEnable()
        {
            healthSystem.OnHealthChanged += UpdateHpBar;
        }

        private void OnDisable()
        {
            healthSystem.OnHealthChanged -= UpdateHpBar;
        }

        private void UpdateHpBar(int obj)
        {
            hpBar.fillAmount = (float) healthSystem.currentHealth  / healthSystem.maxHealth;
        }
    }
}