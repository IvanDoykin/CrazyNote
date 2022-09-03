using UnityEngine;

namespace InternalAssets.Scripts
{
    public class FireAnimator : MonoBehaviour
    {
        private const string fireAnimation = "Fire";
        private Animator[] _animators;

        private void Awake()
        {
            _animators = GetComponentsInChildren<Animator>();
            Note.HasHit += Fire;
        }

        private void OnDestroy()
        {
            Note.HasHit -= Fire;
        }

        public void Fire(int index, bool hit)
        {
            if (hit)
            {
                _animators[index].Play(fireAnimation, -1, 0f);
            }
        }
    }
}