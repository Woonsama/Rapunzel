using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class SoundManager : SingletonMonoBase<SoundManager>
{
    delegate void AudioDelegate();
    private AudioSource targetSource;
    Task delayTask;

    public void PlayOneShot(AudioClip audioClip, float delay = 0, float volume = 1.0f, float pitch = 1.0f)
    {
        AudioDelegate clipPlay = delegate ()
        {
            AudioSource source;
            if (this.gameObject.GetComponent<AudioSource>() == null)
                source = this.gameObject.AddComponent<AudioSource>();
            else
                source = this.gameObject.GetComponent<AudioSource>();
            AudioClip clip = audioClip;
            targetSource = source;

            source.volume = volume;
            source.pitch = pitch;
            source.PlayOneShot(clip);


            delayTask = Task.Delay((int)(delay * 1000));
            Debug.Log(delayTask.IsCompleted);
        };

        if (delayTask == null )
        {
            clipPlay();
        }
        else if(delayTask.IsCompleted)
        {
            clipPlay();
        }        
    }

    public void PlayOneShot(string path, float delay = 0, float volume = 1.0f, float pitch = 1.0f)
    {
        AudioDelegate clipPlay = delegate ()
        {
            AudioSource source;
            if (this.gameObject.GetComponent<AudioSource>() == null)
                source = this.gameObject.AddComponent<AudioSource>();
            else
                source = this.gameObject.GetComponent<AudioSource>();

            AudioClip clip = Resources.Load(path) as AudioClip;
            targetSource = source;

            source.volume = volume;
            source.pitch = pitch;
            source.PlayOneShot(clip);

            delayTask = Task.Delay((int)(delay * 1000));
            Debug.Log(delayTask.IsCompleted);
        };

        if (delayTask == null)
        {
            clipPlay();
        }
        else if (delayTask.IsCompleted)
        {
            clipPlay();
        }
    }

    public void PauseOneShot()
    {
        targetSource.Pause();
    }

    public void UnPauseOneShot()
    {
        targetSource.UnPause();
    }

    public void StopBGM()
    {
        Camera.main.GetComponent<AudioSource>().Stop();
    }

    public void PlayBGM()
    {
        Camera.main.GetComponent<AudioSource>().Play();
    }
    public void PlayBGM(string path, float volume = 1.0f,  bool isLoop = true)
    {
        AudioSource source = Camera.main.GetComponent<AudioSource>();
        source.clip = Resources.Load(path) as AudioClip;
        source.Play();
        source.loop = isLoop;
        source.volume = volume;
    }

    public void PuaseBGM()
    {
        Camera.main.GetComponent<AudioSource>().Pause();
    }

    public void UnPuaseBGM()
    {
        Camera.main.GetComponent<AudioSource>().UnPause();
    }

    public void SetVolumeBGM(float value)
    {
        Camera.main.GetComponent<AudioSource>().volume = value;
    }

    /// <summary>
    /// Set AudioSource Volume
    /// </summary>
    /// <param name="volume">[Min = 0 / Max = 1]</param>
    public void SetVolume(float volume)
    {
        targetSource.volume = volume;
    }

    /// <summary>
    /// Set AudioSource Pitch
    /// </summary>
    /// <param name="pitch">[Min = 0 / MAX = 3]</param>
    public void SetPitch(float pitch)
    {
        targetSource.pitch = pitch;
    }
}
