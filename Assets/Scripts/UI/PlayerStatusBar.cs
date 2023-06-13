using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Entropy.IdlyIsekai.UI
{
    public class PlayerStatusBar : HealthBar
    {
        public override void UpdateHealthBar(int healthChangeValue)
        {
            _currentHealth += healthChangeValue;

            healthBarFill.fillAmount = Mathf.Floor((float)_currentHealth / _maxHealth * 94) / 94f;
            healthText.SetText(_currentHealth.ToString());
            _timeSinceHealthChange = Time.realtimeSinceStartup;
        }
    }
}