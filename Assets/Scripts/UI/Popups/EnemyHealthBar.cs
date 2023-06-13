using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;

namespace Entropy.IdlyIsekai.UI
{
    public class EnemyHealthBar : HealthBar, IPointerEnterHandler, IPointerExitHandler
    {
        [FoldoutGroup("Required")] [Required] public CanvasGroup statsPopup, healthbarPopup;

        private void Update()
        {
            if (Time.realtimeSinceStartup - _timeSinceHealthChange > 5f && statsPopup.alpha == 0) { Hide(); }
            else if(Time.realtimeSinceStartup - _timeSinceHealthChange < 5f) { Show(); }
        }

        public override void Start()
        {
            base.Start();
            Hide();
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