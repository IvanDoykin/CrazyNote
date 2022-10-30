using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAudioFactory
{
    private LoadAudioVorbisNVorbis _loadVorbis;
    private LoadAudioMP3MP3Lib _loadMP3;

    private ILoaderAudio _currentLoader;
    public LoadAudioFactory()
    {
        _loadVorbis = new LoadAudioVorbisNVorbis();
    }
    public void LoadAndSetAudio(string path, string songFormat, AudioSource audio)
    {
        audio.time = 0;
        audio.clip = null;
        audio.Stop();
        if(_currentLoader != null)
            _currentLoader.Dispose();

        if(songFormat == "OGGVORBIS")
        {
            _loadVorbis.LoadAudio(path, audio);
            _currentLoader = _loadVorbis;
            audio.Play();
        }
        else if(songFormat == "MPEG")
        {
            Debug.LogWarning("Load for MPEG not implemented!");
        }
        else
        {
            Debug.LogWarning("Cannot load audio!");
        }
        
    }
}
