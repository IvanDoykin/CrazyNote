using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer 
{
    public class WideObjectPool : ObjectPool<Wide>
    {
        [SerializeField] private GameObject wide;

        private void Awake()
        {
            Clear();
        }

        public GameObject Create(Vector3 position, Quaternion rotation)
        {
            return base.Create(wide, position, rotation);
        }
    }
}