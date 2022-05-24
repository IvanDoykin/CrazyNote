using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class Wide : MonoBehaviour, IPoolable
    {
        private WideObjectPool pool;

        private void Start()
        {
            pool = FindObjectOfType<WideObjectPool>();
        }

        public void SetInPool()
        {
            pool.Delete(gameObject);
        }
    }
}