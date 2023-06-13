using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entropy.IdlyIsekai.Stats
{
    [CreateAssetMenu(menuName ="Data/Player Stats")]
    public class PlayerStats : SerializedScriptableObject
    {
        //Game state variables
        public string characterName;
        public int gold;
        public int exp;
        public int level;

        //Defensive variables
        public int maxHealth;
        public int maxHealthMultiplier;
        public int healthRegeneration;
        public int armor;
        public int defense;
        public int resistance;
        public int dodgeChance;

        //Offensive variables
        public int attack;
        public int attackMultiplier;
        public int attackSpeed;
        public int lifeSteal;
        public int magic;
        public int critChance;
        public int critPower;

        //Support variables
        public int expGain;
        public int goldGain;
        public int luck;

        //Meta Game variables
        public int intel;
        public int intelGain;
        public int systemGold;
    }
}