using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class NotesHandler : MonoBehaviour
    {
        public static float TimeToDetect = 1.9f / Mover.Speed;
        public static float TimeToTrigger = 2.0925f / Mover.Speed;
        public static float TimeToDestroy = 2.23f / Mover.Speed;

        public static float DetectDifferenceTime = 0.4f / Mover.Speed;

        public Action<int, bool> NoteHasHit;
        public Action<int, bool> NoteGroupHasHit;

        public List<NoteGroup> RegistredNoteGroups { get; } = new List<NoteGroup>();
        public bool[] AvailableNoteInRows { get; private set; }

        [SerializeField] private DynamicObjectsFactory _factory;
        private List<NoteGroup> _availableNoteGroups { get; } = new List<NoteGroup>();
        private int[] _availableNotesInRows;

        public void Initialize(int groupSize)
        {
            _factory.NoteGroupHasCreated += RegisterNoteGroup;
            AvailableNoteInRows = new bool[groupSize];
            _availableNotesInRows = new int[groupSize];
        }

        private void OnDestroy()
        {
            _factory.NoteGroupHasCreated -= RegisterNoteGroup;
        }

        public void SetActive()
        {
            foreach (var noteGroup in RegistredNoteGroups)
            {
                noteGroup.SetActive();
            }
        }

        public void SetInactive()
        {
            foreach (var noteGroup in RegistredNoteGroups)
            {
                noteGroup.SetInactive();
            }
        }

        public void Tick()
        {
            for (int i = 0; i < RegistredNoteGroups.Count; i++)
            {
                RegistredNoteGroups[i].Tick();
                if (RegistredNoteGroups[i].Timer > TimeToDestroy)
                {
                    UnregisterNoteGroup(RegistredNoteGroups[i], false);
                    continue;
                }
                if (RegistredNoteGroups[i].Timer > TimeToDetect && !_availableNoteGroups.Contains(RegistredNoteGroups[i]))
                {
                    AddAvailableNotesInRows(RegistredNoteGroups[i]);
                }
            }
        }

        private void AddAvailableNotesInRows(NoteGroup group)
        {
            _availableNoteGroups.Add(group);

            foreach (var note in group.Notes)
            {
                _availableNotesInRows[note.HorizontalPosition]++;
            }

            UpdateAvailableNotesInRows();
        }

        private void RemoveAvailableNotesInRows(NoteGroup group)
        {
            _availableNoteGroups.Remove(group);

            foreach (var note in group.Notes)
            {
                _availableNotesInRows[note.HorizontalPosition]--;
            }

            UpdateAvailableNotesInRows();
        }

        private void UpdateAvailableNotesInRows()
        {
            for (int i = 0; i < _availableNotesInRows.Length; i++)
            {
                AvailableNoteInRows[i] = _availableNotesInRows[i] > 0;
            }
        }

        private void RegisterNoteGroup(NoteGroup group)
        {
            foreach (var note in group.Notes)
            {
                note.HasHit += (int horizontalPosition, bool hit) => NoteHasHit?.Invoke(horizontalPosition, hit);
            }

            RegistredNoteGroups.Add(group);
        }

        private void UnregisterNoteGroup(NoteGroup group, bool hit)
        {
            foreach (var note in group.Notes)
            {
                note.HasHit -= (int horizontalPosition, bool hit) => NoteHasHit?.Invoke(horizontalPosition, hit);
            }

            group.Trigger(hit);
            NoteGroupHasHit?.Invoke(group.Notes.Length, hit);

            RemoveAvailableNotesInRows(group);
            RegistredNoteGroups.Remove(group);
        }

        public void TriggerNoteGroup(NoteGroup group)
        {
            UnregisterNoteGroup(group, true);
        }
    }
}