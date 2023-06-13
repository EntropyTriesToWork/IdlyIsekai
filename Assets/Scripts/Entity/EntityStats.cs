using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Entropy.IdlyIsekai.Stats
{
    [CreateAssetMenu(menuName = "Data/Stats")]
    public class EntityStats : SerializedScriptableObject
    {
        public Dictionary<Stat, int> stats = new Dictionary<Stat, int>();

        [Button]
        public void Default()
        {
            stats = new Dictionary<Stat, int>();
            stats.Add(Stat.Health, 100);
            stats.Add(Stat.Attack, 10);
            stats.Add(Stat.Defense, 1);
            stats.Add(Stat.Speed, 5);
        }
    }
    public enum Stat
    {
        Health,
        Mana,

        Attack,
        Magic,
        Speed,
        Crit,
        CritPower,

        Armor,
        Defense,
        Resistance,
        Dodge,
        Block,

        Luck,
        ExpGain,
    }
}