using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

namespace Entropy.IdlyIsekai.Achievements
{
    public class AchievementManager : MonoBehaviour
    {
        [FoldoutGroup("Required")] [Required] public CanvasGroup achievementPopup, buttonGroupPopup, background;
        [FoldoutGroup("Required")] [Required] public TMP_Text titleText, descriptionText, buttonText;
        [FoldoutGroup("Required")] [Required] public Image achievementIcon;
        [FoldoutGroup("Required")] [Required] public RectTransform achievementRect;
        [FoldoutGroup("Required")] [Required] public VerticalLayoutGroup layoutGroup;

        public static AchievementManager Instance;

        public bool CurrentlyVisible { get; set; }
        public Stack<AchievementData> achievementBacklog = new Stack<AchievementData>();
        private AchievementData currentAchievement;

        private void Awake()
        {
            if(Instance == null) { Instance = this; }
            else { Destroy(gameObject); }

            HideAchievement();
        }

        [Button] public void ShowDebugAchievement(string buttonText)
        {
            ShowAchievement(new AchievementData() { title = "The Best Debug Title", buttonDescription = buttonText, icon = null, description = "Sometimes you just... die. Don't worry though, it's pretty normal nowadays. In fact, dying more is better nowadays!", onButtonPress = ()=> { Debug.Log("This is a debug test achievement bud."); } });
        }

        #region User Interface
        public void ShowAchievement(AchievementData achievement)
        {
            if (CurrentlyVisible) { if(!achievementBacklog.Contains(achievement)) achievementBacklog.Push(achievement); }
            else
            {
                CurrentlyVisible = true;
                ChangeDetailsOnUI(achievement);
            }
        }
        public void HideAchievement()
        {
            StartCoroutine(AchievementAnimation_Out());
        }
        public void ShowNextAchievement()
        {
            StartCoroutine(AchievementAnimation_OutIn());
            IEnumerator AchievementAnimation_OutIn()
            {
                StartCoroutine(AchievementAnimation_Out());
                yield return new WaitForSeconds(0.5f);
                ChangeDetailsOnUI(achievementBacklog.Pop());
                StartCoroutine(AchievementAnimation_In());
            }
        }

        IEnumerator AchievementAnimation_In()
        {
            CurrentlyVisible = true;
            background.DOFade(1f, 0.5f);
            background.interactable = true;
            background.blocksRaycasts = true;
            achievementRect.DOLocalMoveY(-5f, 0, true);

            yield return new WaitForSeconds(0.5f);
            achievementPopup.DOFade(1f, 0.1f);
            achievementRect.DOLocalMoveY(5f, 0.5f).SetEase(Ease.OutQuad);

            yield return new WaitForSeconds(1.5f); // Wait before showing the button;

            buttonGroupPopup.DOFade(1f, 0.2f);
            buttonGroupPopup.interactable = true;
            buttonGroupPopup.blocksRaycasts = true;
        }

        IEnumerator AchievementAnimation_Out()
        {
            background.DOFade(0f, 0.2f);
            background.interactable = false;
            background.blocksRaycasts = false;
            yield return new WaitForSeconds(0.5f);
            achievementPopup.alpha = 0;
            buttonGroupPopup.alpha = 0;
            buttonGroupPopup.interactable = false;
            buttonGroupPopup.blocksRaycasts = false;
            CurrentlyVisible = false;
        }

        public void ButtonPress()
        {
            if(currentAchievement.onButtonPress != null) { currentAchievement.onButtonPress.Invoke(); }
            if(achievementBacklog.Count < 1) { HideAchievement(); }
            else { ShowNextAchievement(); }
        }

        private void ChangeDetailsOnUI(AchievementData achievement)
        {
            currentAchievement = achievement;
            titleText.SetText(achievement.title);
            descriptionText.SetText(achievement.description);
            if (achievement.buttonDescription != "") { buttonText.SetText(achievement.buttonDescription); }
            else { buttonText.SetText("Sure"); }
            layoutGroup.SetLayoutVertical();
            StartCoroutine(AchievementAnimation_In());
        }
        #endregion
    }
    [System.Serializable]
    public struct AchievementData
    {
        public string title;
        public string description;
        public string buttonDescription;
        public Sprite icon;
        public UnityAction onButtonPress;
    }
}