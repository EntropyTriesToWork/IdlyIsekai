using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entropy.IdlyIsekai.Stats;
using Sirenix.OdinInspector;
using UnityEngine.UI;

namespace Entropy.IdlyIsekai.Entities
{
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] protected EntityStats _baseStats;
        public Dictionary<Stat, int> Stats { get; protected set; }
        public float Timeline { get; protected set; }

        [SerializeField] protected Image timelineImage;
        public static int TimelineLength = 100;
        [Required] public int timelineImageWidth;

        private void Awake()
        {
            Initialize();
        }

        [Button] public void Initialize()
        {
            Stats = new Dictionary<Stat, int>(_baseStats.stats);
            if (!Stats.ContainsKey(Stat.Speed)) { Stats.Add(Stat.Speed, 1); }
            if(Stats[Stat.Speed] < 1) { Stats[Stat.Speed] = 1; }
            ResetTimeline();
        }

        public void ResetTimeline()
        {
            Timeline = TimelineLength;
        }
        
        public void AffectTimeline(float time)
        {
            Timeline += time;
            //Add visual notifications

            if(Timeline <= 0f)
            {
                ResetTimeline();
                OnTimeLineComplete();
            }
        }

        public void Tick(int gameSpeed)
        {
            Timeline -= gameSpeed * Stats[Stat.Speed] / 10f * Time.fixedDeltaTime;
            timelineImage.fillAmount = 1f - Mathf.Floor((float)Timeline / TimelineLength * timelineImageWidth) / timelineImageWidth;

            Debug.Log(Timeline);
            if (Timeline <= 0f)
            {
                ResetTimeline();
                OnTimeLineComplete();
            }
        }

        public abstract void OnTimeLineComplete();
    }
}