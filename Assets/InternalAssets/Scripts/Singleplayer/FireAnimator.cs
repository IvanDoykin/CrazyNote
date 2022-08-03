using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class FireAnimator : MonoBehaviour
    {
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
                _animators[index].Play("Fire", -1, 0f);
            }
        }
    }
}