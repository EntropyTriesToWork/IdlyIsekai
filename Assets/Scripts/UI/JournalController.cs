using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Entropy.IdlyIsekai
{
    public class JournalController : MonoBehaviour
    {
        public static JournalController Instance;
        private void Awake()
        {
            if(Instance == null) { Instance = this; }
            else { Destroy(gameObject); }
        }

        public CanvasGroup journal, journalBackground;
        public RectTransform journalRect;

        public bool Visible { get; private set; }
        private void Start()
        {
            Visible = false;
        }

        public void ToggleJournal()
        {
            if (Visible)
            {
                StartCoroutine(JournalAnimation_Out());
            }
            else
            {
                StartCoroutine(JournalAnimation_In());
            }


            IEnumerator JournalAnimation_In()
            {
                Visible = true;
                journal.blocksRaycasts = true;
                journal.interactable = true;
                journalBackground.blocksRaycasts = true;
                journal.DOFade(1f, 0.2f);
                journalBackground.DOFade(1f, 0.2f);
                journalRect.DOLocalMoveY(-30, 0, true);
                journalRect.DOLocalMoveY(-20, 0.5f).SetEase(Ease.OutQuad);
                yield return new WaitForSeconds(0.2f);
                journalBackground.interactable = true;
            }
            IEnumerator JournalAnimation_Out()
            {
                Visible = false;
                journal.blocksRaycasts = false;
                journal.interactable = false;
                journalBackground.blocksRaycasts = false;
                journalBackground.interactable = false;
                journal.DOFade(0f, 0.1f);
                journalBackground.DOFade(0f, 0.1f);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}