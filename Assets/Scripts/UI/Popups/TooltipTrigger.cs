using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;

namespace Entropy.IdlyIsekai.Tooltip
{
    public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public string title;
        [TextArea] public string description;
        public TooltipSize TooltipSize = TooltipSize.S;

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            if(TooltipManager.Instance != null)
            {
                TooltipManager.Instance.ShowToolTip(title, description, GetComponent<RectTransform>(), TooltipSize);
            }
            else { Debug.LogError("Tooltip Manager is missing!"); }
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            if (TooltipManager.Instance != null)
            {
                TooltipManager.Instance.HideToolTip();
            }
        }
    }
}