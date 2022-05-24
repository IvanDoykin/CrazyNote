using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class Destroyer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var poolable = other.GetComponent<IPoolable>();
            if (poolable != null)
            {
                poolable.SetInPool();
            }
        }
    }
}