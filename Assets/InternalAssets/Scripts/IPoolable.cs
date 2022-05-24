using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public interface IPoolable
    {
        public abstract void SetInPool();
    }
}