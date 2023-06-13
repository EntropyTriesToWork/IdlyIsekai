using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Entropy.IdlyIsekai.Entities;

namespace Entropy.IdlyIsekai
{
    public class EncounterManager : MonoBehaviour
    {
        public static EncounterManager Instance;

        [FoldoutGroup("Read Only")] [ReadOnly] public List<Entity> currentEnemies = new List<Entity>();

        private void Awake()
        {
            if (Instance == null) { Instance = this; }
            else { Destroy(gameObject); }
        }
    }
}