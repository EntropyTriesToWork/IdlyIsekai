using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entropy.IdlyIsekai.Entities
{
    public class Enemy : Entity
    {
        public override void OnDeath()
        {
            Destroy(gameObject);
        }

        public override void OnTimeLineComplete()
        {
            
        }
    }
}