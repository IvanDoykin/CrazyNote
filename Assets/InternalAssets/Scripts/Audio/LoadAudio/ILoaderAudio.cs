using UnityEngine;

public interface ILoaderAudio
{
    public void LoadAudio(string path, AudioSource audio);
    public void Dispose();
}