using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class NotesHandler : MonoBehaviour
    {
        public const float TimeToDestroy = 2.185f;
        public const float TimeToDetect = 2.05f;
        public const float DetectDifferenceTime = 0.75f;
        public const float TimeToTrigger = 2.0f;

        public Action<int, bool> NoteHasHit;
        public Action<bool> NoteGroupHasHit;
        
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

        public bool[] GetDetectedInput(NoteGroup group, int inputLength)
        {
            bool[] detectedInput = new bool[inputLength];
            NoteGroup closerNoteGroup = null;
            float closerNoteGroupAbs = 0f;
            foreach (var noteGroup in RegistredNoteGroups)
            {
                if (noteGroup.Notes.Length == 1)
                {
                    if (group != noteGroup && Mathf.Abs(Mathf.Clamp(group.Timer, 0f, 2.13f) - Mathf.Clamp(noteGroup.Timer, 0f, 2.13f)) < DetectDifferenceTime && noteGroup.Timer > TimeToDetect)
                    {
                        closerNoteGroup = noteGroup;
                        closerNoteGroupAbs = Mathf.Abs(Mathf.Clamp(group.Timer, 0f, 2.13f) - Mathf.Clamp(noteGroup.Timer, 0f, 2.13f));
                        detectedInput[noteGroup.Notes[0].HorizontalPosition] = true;
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
            NoteGroupHasHit?.Invoke(hit);
            
            RegistredNoteGroups.Remove(group);
        }

        public bool TryTriggerNoteGroup(NoteGroup group)
        {
            if (group.Timer >= TimeToTrigger)
            {
                UnregisterNoteGroup(group, true);
                return true;
            }

            return false;
        }
    }
}