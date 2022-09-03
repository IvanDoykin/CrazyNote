using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class NoteObjectPool : ObjectPool<Note>
    {
        [SerializeField] private GameObject _notePrefab;
        [SerializeField] private List<Sprite> _noteSprites = new List<Sprite>();

        private void Awake()
        {
            Clear();
        }

        public GameObject Create(Vector3 position, Quaternion rotation, int id)
        {
            var note = base.Create(_notePrefab, position, rotation);
            note.GetComponent<SpriteRenderer>().sprite = _noteSprites[id];
            return note;
        }
    }
}