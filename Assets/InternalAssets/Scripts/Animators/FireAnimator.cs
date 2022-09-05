using System;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class FireAnimator : MonoBehaviour
    {
        private const string fireAnimation = "Fire";
        [SerializeField] private Animator[] _animators;
        [SerializeField] private NotesHandler _notesHandler;

        private void Start()
        {
            _notesHandler.NoteHasHit += Fire;
        }

        private void OnDestroy()
        {
            _notesHandler.NoteHasHit -= Fire;
        }

        private void Fire(int index, bool hit)
        {
            if (hit)
            {
                _animators[index].Play(fireAnimation, -1, 0f);
            }
        }
    }
}