using System;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class DynamicObjectsFactory : MonoBehaviour
    {
        public Action<Note> NoteHasCreated;
        public Action<Wide> WideHasCreated;
        
        [SerializeField] private Transform _widePlace;
        [SerializeField] private NoteSpawnPlaces _notePlaces;

        [SerializeField] private WideObjectPool _widePool;
        [SerializeField] private NoteObjectPool _notePool;

        public Transform WidePlace => _widePlace;
        public NoteSpawnPlaces NotePlaces => _notePlaces;

        public void CreateWide()
        {
            var wideObj = _widePool.Create(_widePlace.position, _widePlace.rotation);
            
            var wide = wideObj.GetComponent<Wide>();
            wide.Initialize(_widePool);
            WideHasCreated?.Invoke(wide);
        }

        public void CreateNote(int id, int position)
        {
            var notePlace = _notePlaces.GetPlaceById(id);
            var noteObj = _notePool.Create(notePlace.position, notePlace.rotation, id);
            
            var note = noteObj.GetComponent<Note>();
            note.Initialize(_notePool, id, position);
            NoteHasCreated?.Invoke(note);
        }
    }
}