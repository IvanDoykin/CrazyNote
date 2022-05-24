using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class NoteObjectPool : ObjectPool<Note>
    {
        [SerializeField] private GameObject note;

        private void Awake()
        {
            Clear();
        }

        public GameObject Create(Vector3 position, Quaternion rotation)
        {
            return base.Create(note, position, rotation);
        }
    }
}