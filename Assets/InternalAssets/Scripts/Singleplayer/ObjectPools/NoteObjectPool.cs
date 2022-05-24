using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class NoteObjectPool : ObjectPool<Note>
    {
        [SerializeField] private List<GameObject> notes = new List<GameObject>();

        private void Awake()
        {
            Clear();
        }

        public GameObject Create(Vector3 position, Quaternion rotation, int id)
        {
            return base.Create(notes[id], position, rotation);
        }
    }
}