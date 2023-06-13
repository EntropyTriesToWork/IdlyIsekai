using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Entropy.IdlyIsekai.Stats
{
    [CreateAssetMenu(menuName = "Data/Stats")]
    public class Stats : SerializedScriptableObject
    {
        public Dictionary<Stat, int> stats = new Dictionary<Stat, int>();

        public enum Stat
        {
            Health,
            MaxMana,
            Mana,

            Attack,
            Magic,
            AttackSpeed,
            Speed,
            Crit,
            Range,

            Defense,
            Resistance,
            Evasion,
            Block,

            Luck,
            ExpGain,
        }
    }
}