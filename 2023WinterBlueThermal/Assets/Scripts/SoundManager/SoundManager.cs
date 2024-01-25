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

    private int _sourcePoolSize = 10;
    private List<AudioSource> _audioSources;
    private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();
    

    //================================================================================================

    public void Play3D(string path, Define.Sound type, Vector3 position, float volume = 1.0f, float pitch = 1.0f)
    {
        Play(path, type, volume, pitch, position);
    }

    public void Play(string path, Define.Sound type, float volume = 1.0f, float pitch = 1.0f, Vector3 position = default(Vector3))
    {
        AudioClip audioClip = GetOrAddAudioClip(path, type);
        if (audioClip == null)
        {
            return;
        }

        Play(audioClip, type, position, volume, pitch);
    }

    public void Play(AudioClip audioClip, Define.Sound type, Vector3 position, float volume, float pitch)
    {
        AudioSource audioSource = GetAvailableAudioSource();
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        
        if (position != default(Vector3))
        {
            audioSource.spatialBlend = 1.0f;
            audioSource.transform.position = position;
        }

        switch (type)
        {
            case Define.Sound.BGM:
                audioSource.Stop();
                audioSource.loop = true;
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

        _audioSources = new List<AudioSource>();

        // Ǯ�� ����� �ҽ� �߰�
        for (int i = 0; i < _sourcePoolSize; i++)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            _audioSources.Add(audioSource);
        }
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
                Debug.Log($"{path} ����� �����͸� ã�� �� �����ϴ�.");
                return null;
            }

            if (type == Define.Sound.Effect)
            {
                _audioClips.Add(path, audioClip);
            }
        }

        return audioClip;
    }

    // ��� ������ ����� �ҽ��� ã�� ��ȯ
    private AudioSource GetAvailableAudioSource()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            if (!audioSource.isPlaying)
            {
                return audioSource;
            }
        }

        // ��� ����� �ҽ��� ��� ���� ��� ���ο� ����� �ҽ��� �����Ͽ� ��ȯ
        AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
        newAudioSource.playOnAwake = false;
        _audioSources.Add(newAudioSource);

        return newAudioSource;
    }
}