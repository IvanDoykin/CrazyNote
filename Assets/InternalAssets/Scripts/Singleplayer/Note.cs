using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class Note : MonoBehaviour, IPoolable
    {
        public int Position { get; private set; }
        private bool _hasCaught = false;
        private NoteObjectPool _pool;

        public void Initialize(int position)
        {
            _pool = FindObjectOfType<NoteObjectPool>();
            Position = position;
        }

        public void Catch()
        {
            _hasCaught = true;
            SetInPool();
        }

        public void SetInPool()
        {
            _pool.Delete(gameObject);
        }
    }
}