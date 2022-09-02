using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class NoteSpawnPlaces : MonoBehaviour
    {
        [SerializeField] private List<Transform> _places = new List<Transform>();

        public Transform GetPlaceById(int id)
        {
            return _places[id];
        }
    }
}