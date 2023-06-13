using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

namespace Entropy.IdlyIsekai.Tooltip
{
    public class TooltipManager : MonoBehaviour
    {
        public static TooltipManager Instance;

        public CanvasGroup tooltipCanvas;
        public TMP_Text tooltipTitle;
        public TMP_Text tooltipDescription;
        public LayoutElement descElement;
        public RectTransform toolTipRect;
        [ReadOnly] public RectTransform elementSelected;

        private void Awake()
        {
            if (Instance == null) { Instance = this; }
            else { Destroy(gameObject); }

            HideToolTip();
        }

        public void ShowToolTip(string title, string desc, RectTransform elementSelected, TooltipSize tooltipSize)
        {
            tooltipCanvas.alpha = 1;
            tooltipTitle.SetText(title);
            tooltipDescription.SetText(desc);
            this.elementSelected = elementSelected;
            descElement.preferredWidth = (int)tooltipSize;
            UpdateTooltipPosition();
        }
        public void HideToolTip()
        {
            tooltipCanvas.alpha = 0;
        }

        public void UpdateTooltipPosition()
        {
            Vector2 threshholds = new Vector2(Screen.width / 2f, Screen.height * 0.75f); //Setting the values at which the tooltip flips.
            Vector2 newPivot = new Vector2();
            if(elementSelected.position.x > threshholds.x) { newPivot.x = 1; }
            if(elementSelected.position.y > threshholds.y) { newPivot.y = 1; }
            toolTipRect.pivot = newPivot;
            Vector3 offsetPosition = elementSelected.sizeDelta;
            //offsetPosition.x *= newPivot.x > 0 ? -1.25f : 1.25f;
            offsetPosition.x = 0;
            offsetPosition.y *= newPivot.y > 0 ? -2.5f : 2.5f;
            toolTipRect.position = elementSelected.position + offsetPosition;
            toolTipRect.DOMoveY(toolTipRect.position.y + 10, 0.2f);
        }
    }
    public enum TooltipSize
    {
        S = 100,
        M = 150,
        L = 200,
        XL = 250
    }
}