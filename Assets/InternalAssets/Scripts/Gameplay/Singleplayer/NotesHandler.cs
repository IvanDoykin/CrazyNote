using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class NotesHandler : MonoBehaviour
    {
        public const float TimeToDestroy = 2.13f;
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
                group.Trigger(true);
                NoteGroupHasHit?.Invoke(true);

                UnregisterNoteGroup(group, true);
                return true;
            }

            return false;
        }
    }
}