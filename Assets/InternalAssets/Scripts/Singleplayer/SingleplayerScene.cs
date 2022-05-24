using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class SingleplayerScene : MonoBehaviour
    {
        [SerializeField] private Transform widePlace;
        public Transform WidePlace => widePlace;

        private WideObjectPool widePool;

        private void Awake()
        {
            widePool = FindObjectOfType<WideObjectPool>();
        }

        public void CreateWide()
        {
            widePool.Create(widePlace.position, widePlace.rotation);
        }
    }
}