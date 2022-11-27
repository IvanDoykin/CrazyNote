using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class MenuAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource[] _sources;
        [SerializeField] private List<AudioClip> _nextClips;
        [SerializeField] private List<AudioClip> _backClips;
        [SerializeField] private AudioClip _firstPlayClip;
        [SerializeField] private AudioClip _buttonSelectedClip;

        [ContextMenu("First")]
        public void FirstPlay()
        {
            AudioSource source = SelectFreeSource();

            source.clip = _firstPlayClip;
            source.Play();
        }

        [ContextMenu("Next")]
        public void PlayNext()
        {
            AudioSource source = SelectFreeSource();

            source.clip = _nextClips[Random.Range(0, _nextClips.Count)];
            source.Play();
        }

        [ContextMenu("Back")]
        public void PlayBack()
        {
            AudioSource source = SelectFreeSource();

            source.clip = _backClips[Random.Range(0, _backClips.Count)];
            source.Play();
        }

        [ContextMenu("Selected")]
        public void PlayButtonSelected()
        {
            AudioSource source = SelectFreeSource();

            source.clip = _buttonSelectedClip;
            source.Play();
        }
        
        private AudioSource SelectFreeSource()
        {
            foreach (var source in _sources)
            {
                if (!source.isPlaying)
                {
                    return source;
                }
            }

            return _sources[0];
        }
    }
}