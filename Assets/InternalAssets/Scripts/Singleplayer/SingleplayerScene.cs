using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class SingleplayerScene : MonoBehaviour
    {
        [SerializeField] private Transform widePlace;
        [SerializeField] private NoteSpawnPlaces notePlaces;
        public Transform WidePlace => widePlace;
        public NoteSpawnPlaces NotePlaces => notePlaces;

        [SerializeField] private WideObjectPool widePool;
        [SerializeField] private NoteObjectPool notePool;

        public void CreateWide()
        {
            widePool.Create(widePlace.position, widePlace.rotation);
        }

        public void CreateNote(int id)
        {
            Transform notePlace = notePlaces.GetPlaceById(id);
            GameObject note = notePool.Create(notePlace.position, notePlace.rotation, id);
            note.GetComponent<Note>().Initialize(id);
        }
    }
}