using NLayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAudioMP3NLayer : ILoaderAudio
{
    private string clipName;
    private int lengthSamples;
    private int channels;
    private int frequency;
    private bool isStream;

    private MpegFile stream;

    public void LoadAudio(string path, AudioSource audio)
    {
        stream = new MpegFile(path);
        clipName = "clipName";
        lengthSamples = (int)stream.Length;
        channels = stream.Channels;
        frequency = stream.SampleRate;
        isStream = true;
        AudioClip clip = AudioClip.Create(clipName, lengthSamples, channels, frequency, isStream, PcmRead, PcmSetPosition);
        audio.clip = clip;
    }
    private void PcmRead(float[] data)
    {
        if (stream != null)
            stream.ReadSamples(data, 0, data.Length);

    }
    private void PcmSetPosition(int postition)
    {
        stream.Position = postition;
    }
    public void Dispose()
    {
        stream.Dispose();
    }
}
