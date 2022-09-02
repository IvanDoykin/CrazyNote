using UnityEngine;

namespace InternalAssets.Scripts
{
    public class DynamicObjectsFactory : MonoBehaviour
    {
        [SerializeField] private Transform _widePlace;
        [SerializeField] private NoteSpawnPlaces _notePlaces;

        [SerializeField] private WideObjectPool _widePool;
        [SerializeField] private NoteObjectPool _notePool;

        public Transform WidePlace => _widePlace;
        public NoteSpawnPlaces NotePlaces => _notePlaces;

        public void CreateWide()
        {
            var wide = _widePool.Create(_widePlace.position, _widePlace.rotation);
            wide.GetComponent<Wide>().Initialize(_widePool);
        }

        public void CreateNote(int id, int position)
        {
            var notePlace = _notePlaces.GetPlaceById(id);
            var note = _notePool.Create(notePlace.position, notePlace.rotation, id);
            note.GetComponent<Note>().Initialize(_notePool, id, position);
        }
    }
}