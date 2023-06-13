using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;

namespace Entropy.IdlyIsekai.Tooltip
{
    public class TooltipDelayedTrigger : TooltipTrigger
    {
        public float delayTime = 1f;

        private bool _hovering = false;
        private float _remainingDelayTime = 1f;

        private void FixedUpdate()
        {
            if (_hovering) { _remainingDelayTime -= Time.fixedDeltaTime; }
            
            if(_remainingDelayTime <= 0f)
            {
                TooltipManager.Instance.ShowToolTip(title, description, GetComponent<RectTransform>(), TooltipSize);
            }
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (TooltipManager.Instance != null)
            {
                _hovering = true;
            }
            else { Debug.LogError("Tooltip Manager is missing!"); }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            if (TooltipManager.Instance != null)
            {
                TooltipManager.Instance.HideToolTip();
                _hovering = false;
                _remainingDelayTime = delayTime;
            }
        }
    }
}