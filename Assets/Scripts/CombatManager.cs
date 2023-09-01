using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entropy.IdlyIsekai.Entities;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.UI;
using Entropy.IdlyIsekai.UI;

namespace Entropy.IdlyIsekai
{
    public class CombatManager : MonoBehaviour
    {
        public static CombatManager Instance;

        [BoxGroup("Read Only")] [ReadOnly] public List<Entity> entities = new List<Entity>();
        [BoxGroup("Read Only")] [ReadOnly] public CombatState CombatState;

        [BoxGroup("Required")] public PlayerStatusBar playerStatusBar;
        [BoxGroup("Required")] public Player player;
        [BoxGroup("Required")] public Transform spawnParent;

        public void SpawnEntity(GameObject gameObject)
        {
            GameObject go = Instantiate(gameObject, spawnParent);
            Entity entity = go.GetComponent<Entity>();
            if (entity == null) { Destroy(go); }
            else { entities.Add(entity); Debug.Log("Testing"); }
        }

        public Entity GetNearestTarget()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].enabled) { return entities[i]; }
            }
            return null;
        }

        #region DungeonManager
        [BoxGroup("Debug")] [SerializeField] private GameObject _enemyPrefab;
        [BoxGroup("Debug")] [SerializeField] private int _spawnCount;
        [BoxGroup("Debug")] [Button] private void SpawnEnemies()
        {
            for (int i = 0; i < _spawnCount; i++)
            {
                SpawnEntity(_enemyPrefab);
            }
        }
        #endregion

        private void Awake()
        {
            if (Instance == null) { Instance = this; }
            else { Destroy(gameObject); }

            CombatState = CombatState.Normal;
            entities = new List<Entity>();
        }

        private void FixedUpdate()
        {
            if((int)CombatState > 0)
            {
                for (int i = 0; i < entities.Count; i++)
                {
                    if (entities[i] == null) { entities.RemoveAt(i); }
                    else { entities[i].Tick((int)CombatState); }
                }
                player.Tick((int)CombatState);
            }
        }
    }
    public enum CombatState
    {
        Paused = 0,
        Slowmo = 2,
        Normal = 10,
        Fast = 20,
        VeryFast = 30
    }
}