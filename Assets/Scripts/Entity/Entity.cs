using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entropy.IdlyIsekai.Stats;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using Entropy.IdlyIsekai.UI;

namespace Entropy.IdlyIsekai.Entities
{
    public abstract class Entity : MonoBehaviour, IDamageable
    {
        public Dictionary<Stat, int> Stats { get; protected set; }
        public float Timeline { get; protected set; }

        [FoldoutGroup("Required")] [Required] [SerializeField] protected EntityStats _baseStats;
        [FoldoutGroup("Required")] [Required] [SerializeField] protected Image timelineImage;
        [FoldoutGroup("Required")] [Required] public int timelineImageWidth;
        [FoldoutGroup("Required")] [Required] public HealthBar healthBar;

        public static int TimelineLength = 100;

        private void Awake()
        {
            Initialize();
        }

        #region State
        [Button] public void Initialize()
        {
            Stats = new Dictionary<Stat, int>(_baseStats.stats);
            if (!Stats.ContainsKey(Stat.Speed)) { Stats.Add(Stat.Speed, 1); }
            if(Stats[Stat.Speed] < 1) { Stats[Stat.Speed] = 1; }
            ResetTimeline();
            healthBar.InitializeHealthBar(Stats[Stat.Health]);
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

            if (Timeline <= 0f)
            {
                ResetTimeline();
                OnTimeLineComplete();
            }
        }
        #endregion

        #region Combat
        public DamageReport TakeDamage(DamageInfo damageInfo)
        {
            float subtotalDamage = damageInfo.damage;
            DamageReport report = new DamageReport();

            int finalDamage = Mathf.RoundToInt(subtotalDamage);
            Health -= finalDamage;
            
            report.damageTaken = finalDamage;

            healthBar.UpdateHealthBar(-finalDamage);
            if(Health <= 0) { OnDeath(); }
            return report;
        }
        public DamageReport DealDamage(DamageInfo damageInfo)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Getters
        public int Health { get => _health; protected set => Mathf.Max(0, _health += value); }
        private int _health;
        #endregion

        public abstract void OnTimeLineComplete();
        public abstract void OnDeath();
    }
}