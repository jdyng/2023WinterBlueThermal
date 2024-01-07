using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance = null;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject();
                go.name = "@SoundManager";
                _instance = go.AddComponent<SoundManager>();
                _instance.Init();
            }

            return _instance;
        }
        private set { }
    }

    private AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];
    private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    //================================================================================================

    public void Play(string path, Define.Sound type, float volume = 1.0f, float pitch = 1.0f)
    {
        AudioClip audioClip = GetOrAddAudioClip(path, type);
        if (audioClip == null)
        {
            return;
        }

        Play(audioClip, type, volume, pitch);
    }

    public void Play(AudioClip audioClip, Define.Sound type, float volume, float pitch)
    {
        AudioSource audioSource = _audioSources[(int)type];
        audioSource.volume = volume;
        audioSource.pitch = pitch;

        switch (type)
        {
            case Define.Sound.BGM:
                audioSource.Stop();
                audioSource.clip = audioClip;
                audioSource.Play();
                break;
            case Define.Sound.Effect:
                audioSource.PlayOneShot(audioClip);
                break;
        }
    }

    private void Init()
    {
        DontDestroyOnLoad(_instance);

        string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));
        for (int i = 0; i < soundNames.Length - 1; i++)
        {
            GameObject soundObject = new GameObject { name = soundNames[i] };
            _audioSources[i] = soundObject.AddComponent<AudioSource>();
            _audioSources[i].playOnAwake = false;
            soundObject.transform.parent = this.transform;
        }

        _audioSources[(int)Define.Sound.BGM].loop = true;
    }

    private SoundManager() { }

    private AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.Effect)
    {
        if (path.Contains("Sounds/") == false)
        {
            path = $"Sounds/{path}";
        }

        AudioClip audioClip = null;
        if (_audioClips.TryGetValue(path, out audioClip) == false)
        {
            audioClip = Resources.Load<AudioClip>(path);
            if (audioClip == null)
            {
                Debug.Log($"{path} 경로의 데이터를 찾을 수 없습니다.");
                return null;
            }

            if (type == Define.Sound.Effect)
            {
                _audioClips.Add(path, audioClip);
            }
        }

        return audioClip;
    }
}