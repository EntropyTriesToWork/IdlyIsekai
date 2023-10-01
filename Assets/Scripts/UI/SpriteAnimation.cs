using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Sirenix.OdinInspector;

namespace Entropy.IdlyIsekai.UI
{
    public class SpriteAnimation : MonoBehaviour
    {
        public Sprite[] idleSprites;
        public Sprite[] runningSprites;
        [BoxGroup("Settings")] public float fps = 4;
        [BoxGroup("Settings")] public bool loop = true;
        [BoxGroup("Settings")] [HideIf("loop")] public bool destroyOnEnd = false;
        [BoxGroup("Settings")] [HideIf("destroyOnEnd")] public bool pauseOnEnd = false;

        public AnimationState AnimState = AnimationState.Normal;

        private int index = 0;
        private SpriteRenderer spriteRenderer;
        private Sprite[] _currentSprites;

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            _currentSprites = runningSprites;
        }

        void Start()
        {
            StartCoroutine(Animation());
        }

        private IEnumerator Animation()
        {
            float tick = 1f / fps;
            while(AnimState == AnimationState.Normal)
            {
                if (!loop && index == _currentSprites.Length) yield break;
                
                spriteRenderer.sprite = _currentSprites[index];
                index++;
                if (index >= _currentSprites.Length)
                {
                    if (loop) index = 0;
                    else if (destroyOnEnd) Destroy(gameObject);
                    else if (pauseOnEnd) { AnimState = AnimationState.Paused; }
                }
                yield return new WaitForSeconds(tick);
            }
        }

        [ButtonGroup("Animation")] public void Idle()
        {
            _currentSprites = idleSprites;
            index = 0;
        }
        [ButtonGroup("Animation")] public void Run()
        {
            _currentSprites = runningSprites;
            index = 0;
        }
    }
    public enum AnimationState
    {
        Normal,
        Paused
    }
}