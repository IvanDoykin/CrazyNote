using System;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class Note : MonoBehaviour, IPoolable
    {
        public Action<Note> HasInitialized;
        public Action<int, bool> HasHit;

        [SerializeField] private Mover _mover;
        private NoteObjectPool _pool;

        public int HorizontalPosition { get; private set; }

        public void SetInPool()
        {
            _pool.Delete(gameObject);
        }

        public void SetActive()
        {
            _mover.SetActive();
        }

        public void SetInactive()
        {
            _mover.SetInactive();
        }

        public void Initialize(NoteObjectPool pool, int horizontalPosition)
        {
            _pool = pool;
            HorizontalPosition = horizontalPosition;

            HasInitialized?.Invoke(this);
        }

        public void Remove(bool hit)
        {
            HasHit?.Invoke(HorizontalPosition, hit);
            SetInPool();
        }
    }
}