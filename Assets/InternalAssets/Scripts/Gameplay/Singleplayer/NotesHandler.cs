using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class NotesHandler : MonoBehaviour
    {
        public const float TimeToDestroy = 2.2f / 1.000f;
        public const float TimeToDetect = 2.0f / 1.000f;
        public const float DetectDifferenceTime = 0.4f / 1.000f;
        public const float TimeToTrigger = 2.05f / 1.000f;

        public Action<int, bool> NoteHasHit;
        public Action<int, bool> NoteGroupHasHit;

        public List<NoteGroup> RegistredNoteGroups { get; } = new List<NoteGroup>();

        [SerializeField] private DynamicObjectsFactory _factory;

        private void Start()
        {
            _factory.NoteGroupHasCreated += RegisterNoteGroup;
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

        public bool[] GetDetectedInput(NoteGroup group, int inputLength)
        {
            bool[] detectedInput = new bool[inputLength];
            NoteGroup closerNoteGroup = null;
            float closerNoteGroupAbs = 0f;
            foreach (var noteGroup in RegistredNoteGroups)
            {
                if (group != noteGroup && Mathf.Abs(Mathf.Clamp(group.Timer, 0f, 2.12f/ 1.000f) - Mathf.Clamp(noteGroup.Timer, 0f, 2.12f/ 1.000f)) < DetectDifferenceTime && noteGroup.Timer > TimeToDetect)
                {
                    closerNoteGroup = noteGroup;
                    closerNoteGroupAbs = Mathf.Abs(Mathf.Clamp(group.Timer, 0f, 2.12f/ 1.000f) - Mathf.Clamp(noteGroup.Timer, 0f, 2.12f/ 1.000f));
                    for (int i = 0; i < noteGroup.Notes.Length; i++)
                    {
                        detectedInput[noteGroup.Notes[i].HorizontalPosition] = true;
                    }
                }
            }

            if (closerNoteGroup != null)
            {
                Debug.Log("Abs behind #" + group.VerticalPosition + " and #" + closerNoteGroup.VerticalPosition + " = " + closerNoteGroupAbs);
                detectedInput.Log();
            }
            return detectedInput;
        }

        public void Tick()
        {
            for (int i = 0; i < RegistredNoteGroups.Count; i++)
            {
                RegistredNoteGroups[i].Tick();
                if (RegistredNoteGroups[i].Timer > TimeToDestroy)
                {
                    UnregisterNoteGroup(RegistredNoteGroups[i], false);
                }
            }
        }

        private void RegisterNoteGroup(NoteGroup group)
        {
            Debug.Log("register note");
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

            RegistredNoteGroups.Remove(group);
        }

        public void TriggerNoteGroup(NoteGroup group)
        {
            UnregisterNoteGroup(group, true);
        }
    }
}