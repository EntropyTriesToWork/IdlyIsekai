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

            healthBarFill.fillAmount = Mathf.Floor((float)_currentHealth / _maxHealth * 94) / 94f; //94 because that's the number of pixels in length of the health bar
            healthText.SetText(_currentHealth.ToString());
            _timeSinceHealthChange = Time.realtimeSinceStartup;
        }
    }
}