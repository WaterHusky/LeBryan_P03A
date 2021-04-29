using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxHandler : MonoBehaviour
{
    public static SfxHandler sfxHandler;

    public AudioSource[] sources;

    public static AudioSource Play(AudioClip clip, float pitch = 1f)
    {
        AudioSource source = null;
        for (int i = 0; i < sfxHandler.sources.Length; i++)
        {
            if (!sfxHandler.sources[i].isPlaying)
            {
                source = sfxHandler.sources[i];
                i = sfxHandler.sources.Length;
            }
        }
        if (source == null)
        {
            float mostFinished = 0;
            int mostFinishedIndex = 0;
            //Find the source closest to finishing playing it's clip
            for (int i = 0; i < sfxHandler.sources.Length; i++)
            {
                if (sfxHandler.sources[i].clip != null)
                {
                    if (sfxHandler.sources[i].clip.length != 0)
                    {
                        if ((sfxHandler.sources[i].timeSamples / sfxHandler.sources[i].clip.length) > mostFinished)
                        {
                            mostFinished = sfxHandler.sources[i].timeSamples / sfxHandler.sources[i].clip.length;
                            mostFinishedIndex = i;
                        }
                    }
                }
            }
            //play the new clip on the source with the highest played percentage
            source = sfxHandler.sources[mostFinishedIndex];
        }
        source.clip = clip;
        source.volume = PlayerPrefs.GetFloat("sfxVolume");
        source.pitch = pitch;
        source.Play();

        return source;
    }
}
