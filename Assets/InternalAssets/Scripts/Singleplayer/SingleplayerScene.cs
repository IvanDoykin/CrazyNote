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

        private WideObjectPool widePool;
        private NoteObjectPool notePool;

        private void Awake()
        {
            widePool = FindObjectOfType<WideObjectPool>();
            notePool = FindObjectOfType<NoteObjectPool>();

            notePlaces = FindObjectOfType<NoteSpawnPlaces>();
        }

        public void CreateWide()
        {
            widePool.Create(widePlace.position, widePlace.rotation);
        }

        public void CreateNote(int id)
        {
            Transform notePlace = notePlaces.GetPlaceById(id);
            notePool.Create(notePlace.position, notePlace.rotation, id);
        }
    }
}