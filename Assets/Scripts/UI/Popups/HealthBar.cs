using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;

namespace Entropy.IdlyIsekai.UI
{
    public class HealthBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [FoldoutGroup("Required")] [Required] public Image healthBarFill;
        [FoldoutGroup("Required")] [Required] public TMP_Text healthNumber;
        [FoldoutGroup("Required")] [Required] public CanvasGroup statsPopup, healthbarPopup;
        private int _maxHealth;
        private int _currentHealth;

        [FoldoutGroup("Debug")] public bool initializeOnStart = false;
        [FoldoutGroup("Debug")] [ShowIf("initializeOnStart")] public int debugStartingHealth = 100;

        private float _timeSinceHealthChange = 0;

        private void Start()
        {
            statsPopup.alpha = 0;
            if (initializeOnStart)
            {
                InitializeHealthBar(debugStartingHealth);
            }
        }
        private void Update()
        {
            if (Time.realtimeSinceStartup - _timeSinceHealthChange > 5f && statsPopup.alpha == 0) { Hide(); }
            else if(Time.realtimeSinceStartup - _timeSinceHealthChange < 5f) { Show(); }
        }

        public void UpdateHealthBar(int healthChangeValue)
        {
            _currentHealth += healthChangeValue;

            healthBarFill.fillAmount = (float)_currentHealth / (float)_maxHealth;
            healthNumber.text = _currentHealth.ToString();
            _timeSinceHealthChange = Time.realtimeSinceStartup;
        }

        public void InitializeHealthBar(int maxHealth)
        {
            _currentHealth = maxHealth;
            _maxHealth = maxHealth;
            UpdateHealthBar(0);
        }

        public void Show()
        {
            healthbarPopup.alpha = 1;
        }
        public void Hide()
        {
            healthbarPopup.alpha = 0;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            statsPopup.alpha = 1;
            Show();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            statsPopup.alpha = 0;
            Hide();
        }
    }
}