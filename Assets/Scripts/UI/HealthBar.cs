using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Entropy.IdlyIsekai.UI
{
    public class HealthBar : MonoBehaviour
    {
        [FoldoutGroup("Required")] [Required] public Image healthBarFill;
        [FoldoutGroup("Required")] [Required] public TMP_Text healthText;

        protected int _maxHealth;
        protected int _currentHealth;
        protected float _timeSinceHealthChange = 0;

        [FoldoutGroup("Debug")] public bool initializeOnStart = false;
        [FoldoutGroup("Debug")] [ShowIf("initializeOnStart")] public int debugStartingHealth = 100;

        public virtual void Start()
        {
            if (initializeOnStart)
            {
                InitializeHealthBar(debugStartingHealth);
            }
        }

        public virtual void UpdateHealthBar(int healthChangeValue)
        {
            _currentHealth += healthChangeValue;

            healthBarFill.fillAmount = Mathf.Floor((float)_currentHealth / (float)_maxHealth * 28f) / 28f;
            healthText.text = _currentHealth.ToString();
            _timeSinceHealthChange = Time.realtimeSinceStartup;
        }
        public void SetMaxHealth(int maxHealth)
        {
            _maxHealth = maxHealth;
            if(_currentHealth > _maxHealth) { _currentHealth = _maxHealth; }
            UpdateHealthBar(0);
        }
        public virtual void InitializeHealthBar(int maxHealth)
        {
            _currentHealth = maxHealth;
            _maxHealth = maxHealth;
            UpdateHealthBar(0);
        }
    }
}