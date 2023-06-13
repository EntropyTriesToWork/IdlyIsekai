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

        public int combatSpeed = 1;
        [BoxGroup("Read Only")]  public List<Entity> entities = new List<Entity>();
        [BoxGroup("Read Only")] [ReadOnly] public CombatState CombatState;

        [BoxGroup("Required")] public PlayerStatusBar playerStatusBar;

        private void Awake()
        {
            if (Instance == null) { Instance = this; }
            else { Destroy(gameObject); }

            CombatState = CombatState.Normal;
        }

        private void FixedUpdate()
        {
            if((int)CombatState > 0)
            {
                for (int i = 0; i < entities.Count; i++)
                {
                    entities[i].Tick((int)CombatState);
                }
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