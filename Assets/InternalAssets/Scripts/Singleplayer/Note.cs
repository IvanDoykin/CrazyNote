using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class Note : MonoBehaviour, IPoolable
    {
        private NoteObjectPool pool;

        private void Start()
        {
            pool = FindObjectOfType<NoteObjectPool>();
        }

        public void SetInPool()
        {
            pool.Delete(gameObject);
        }
    }
}