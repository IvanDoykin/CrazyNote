using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawnPlaces : MonoBehaviour
{
    [SerializeField] private List<Transform> places = new List<Transform>();

    public Transform GetPlaceById(int id)
    {
        return places[id];
    }
}
