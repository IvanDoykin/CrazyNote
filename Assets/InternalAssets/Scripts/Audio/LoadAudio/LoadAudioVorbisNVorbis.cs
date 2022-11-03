using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAudioVorbisNVorbis : ILoaderAudio
{
    private string clipName;
    private int lengthSamples;
    private int channels;
    private int frequency;
    private bool isStream;

    private NVorbis.VorbisReader vorbisStream;

    public void LoadAudio(string path, AudioSource audio)
    {
        vorbisStream = new NVorbis.VorbisReader(path);
        vorbisStream.ClipSamples = true;
        clipName = vorbisStream.Tags.Artist + " - " + vorbisStream.Tags.Title;
        lengthSamples = (int)vorbisStream.TotalSamples;
        channels = vorbisStream.Channels;
        frequency = vorbisStream.SampleRate;
        isStream = true;

        AudioClip clip = AudioClip.Create(clipName, lengthSamples, channels, frequency, isStream, PcmRead, PcmSetPosition);
        audio.clip = clip;
    }
    private void PcmRead(float[] data)
    {
        if(vorbisStream != null)
            vorbisStream.ReadSamples(data, 0, data.Length);
    }
    private void PcmSetPosition(int postition)
    {
        vorbisStream.SamplePosition = postition;
    }
    public void Dispose()
    {
        vorbisStream.Dispose();
    }
}
