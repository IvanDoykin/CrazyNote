using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class FireAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void Play()
        {
            _animator.SetBool("fire", true);
        }

        public void ResetToIdle()
        {
            _animator.SetBool("fire", false);
        }
    }
}