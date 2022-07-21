using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class Note : MonoBehaviour, IPoolable
    {
        public static Action<Note> HasCreated;
        public float Timer { get; private set; }

        public int HorizontalPosition { get; private set; }
        private NoteObjectPool _pool;

        public void Initialize(int horizontalPosition)
        {
            Timer = 0f;

            if (_pool == null)
            {
                _pool = FindObjectOfType<NoteObjectPool>();
            }

            HorizontalPosition = horizontalPosition;
            HasCreated?.Invoke(this);
        }

        public void Tick()
        {
            Timer += Time.deltaTime;
        }

        public void SetInPool()
        {
            Debug.Log("set in pool");
            _pool.Delete(gameObject);
        }
    }
}