using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entropy.IdlyIsekai.Stats;

namespace Entropy.IdlyIsekai.Entities
{
    public class Player : Entity
    {
        public Entity currentTarget;

        public override void OnDeath()
        {
            Debug.Log("Player Death not implemented yet");
        }

        public override void OnTimeLineComplete()
        {
            if(currentTarget == null) { currentTarget = CombatManager.Instance.GetNearestTarget(); }
            if(currentTarget == null) { return; }

            currentTarget.TakeDamage(new DamageInfo() { damage = Stats[Stat.Attack] });
        }
    }
}