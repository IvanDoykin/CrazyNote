using System;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class Note : MonoBehaviour, IPoolable
    {
        public static Action<Note> HasInitialized;
        public static Action<int, bool> HasHit;

        private NoteObjectPool _pool;

        public float Timer { get; private set; }

        public int HorizontalPosition { get; private set; }
        public int VerticalPosition { get; private set; }

        public void SetInPool()
        {
            _pool.Delete(gameObject);
        }

        public void Initialize(NoteObjectPool pool, int horizontalPosition, int verticalPosition)
        {
            _pool = pool;
            HorizontalPosition = horizontalPosition;
            VerticalPosition = verticalPosition;

            Timer = NotesDetector.TimeToRegister;
            Invoke(nameof(PostInitialize), NotesDetector.TimeToRegister);
        }

        private void PostInitialize()
        {
            HasInitialized?.Invoke(this);
        }

        public void Tick()
        {
            Timer += Time.deltaTime;
        }

        public void Remove(bool hit)
        {
            HasHit?.Invoke(HorizontalPosition, hit);
            SetInPool();
        }
    }
}