using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entropy.IdlyIsekai.Entities
{
    public class HealthComponent : MonoBehaviour, IDamageable
    {
        public DamageReport TakeDamage(DamageInfo damageInfo)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IDamageable
    {
        public DamageReport TakeDamage(DamageInfo damageInfo);
    }

    public struct DamageReport
    {
        public int damageTaken;
        public int damageReduced;
        public bool isCrit;
        public DamageType damageType;
        public bool isDead;
    }
    public struct DamageInfo
    {
        public int damage; //Total damage should already be calculated before being sent over. 
        public DamageType damageType;
        public int critChance;
        public int critPower;
    }

    public enum DamageType
    {
        Physical = 0,
        Magic = 1,
        Mixed = 2,
        True = 99
    }
}