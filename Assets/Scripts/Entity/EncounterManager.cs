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

        public GameObject enemyPrefab;
        public int spawnCount;

        private void Awake()
        {
            if (Instance == null) { Instance = this; }
            else { Destroy(gameObject); }
        }

        [Button] public void SpawnEnemies()
        {
            for (int i = 0; i < spawnCount; i++)
            {
                CombatManager.Instance.SpawnEntity(enemyPrefab);
            }
        }
    }
}