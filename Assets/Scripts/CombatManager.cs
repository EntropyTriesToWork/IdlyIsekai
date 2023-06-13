using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entropy.IdlyIsekai
{
    public class CombatManager : MonoBehaviour
    {
        public static CombatManager Instance;

        public int combatSpeed = 1;

        private void Awake()
        {
            if (Instance == null) { Instance = this; }
            else { Destroy(gameObject); }
        }
    }
}