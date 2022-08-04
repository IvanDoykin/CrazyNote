using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class Note : MonoBehaviour, IPoolable
    {
        public static Action<Note> HasInitialized;
        public static Action<int, bool> HasHit;

        public float Timer { get; private set; }

        public int HorizontalPosition { get; private set; }
        public int VerticalPosition { get; private set; }

        private NoteObjectPool _pool;

        public void Initialize(int horizontalPosition, int verticalPosition)
        {
            if (_pool == null)
            {
                _pool = FindObjectOfType<NoteObjectPool>();
            }

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

        public void SetInPool()
        {
            _pool.Delete(gameObject);
        }
    }
}