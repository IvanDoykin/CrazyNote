using System;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class DynamicObjectsFactory : MonoBehaviour
    {
        public Action<NoteGroup> NoteGroupHasCreated;
        public Action<Wide> WideHasCreated;

        [SerializeField] private Transform _widePlace;
        [SerializeField] private NoteSpawnPlaces _notePlaces;

        [SerializeField] private WideObjectPool _widePool;
        [SerializeField] private NoteObjectPool _notePool;

        public Transform WidePlace => _widePlace;
        public NoteSpawnPlaces NotePlaces => _notePlaces;

        public Wide CreateWide()
        {
            var wideObj = _widePool.Create(_widePlace.position, _widePlace.rotation);
            
            var wide = wideObj.GetComponent<Wide>();
            wide.Initialize(_widePool);
            WideHasCreated?.Invoke(wide);

            return wide;
        }

        public NoteGroup CreateNotesGroup(Note[] notes, int verticalPosition)
        {
            var group = new NoteGroup(notes, verticalPosition);
            NoteGroupHasCreated?.Invoke(group);

            return group;
        }
        
        public Note CreateNote(int id)
        {
            var notePlace = _notePlaces.GetPlaceById(id);
            var noteObj = _notePool.Create(notePlace.position, notePlace.rotation, id);
            
            var note = noteObj.GetComponent<Note>();
            note.Initialize(_notePool, id);

            return note;
        }
    }
}