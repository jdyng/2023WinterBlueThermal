using System.Collections;
using TMPro;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class StageClearUI : UI_Scene
{
    [SerializeField] private AudioClip _textAudioClip;
    [SerializeField] private AudioSource _audioSource;

    private string _stageName;
    private int _killsLog = 0;
    private int _itemsLog = 0;
    private float _timeLog = 0f;
    private float _parLog = 0f;

    private TextsInLogs[] _textsInLogs;

    private bool _skip = false;

    enum TextsInLogs
    {
        KillsLog = 0,
        ItemsLog,
        TimeLog,
        PARLog
    }

    public override void Init()
    {
        base.Init();
        LevelHandler.Instance.GetLogs(out _stageName, out _killsLog, out _itemsLog, out _timeLog, out _parLog);

        Util.FindChild<TextMeshProUGUI>(this.gameObject, "StageName", true).text = _stageName;

        Bind<TextMeshProUGUI>(typeof(TextsInLogs));
        _textsInLogs = (TextsInLogs[])Enum.GetValues(typeof(TextsInLogs));

        foreach (TextsInLogs textInLog in _textsInLogs)
        {
            GetText((int)textInLog).enabled = false;
        }
    }

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        StartCoroutine(DisplayLogs());
    }

    private void Update()
    {
        Skip();
    }

    private IEnumerator DisplayLogs()
    {
        float[] data = new float[] { _killsLog, _itemsLog, _timeLog, _parLog };

        for (int i = 0; i < _textsInLogs.Length; i++)
        {
            yield return StartCoroutine(ShowLog(_textsInLogs[i], data[i]));

            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator ShowLog(TextsInLogs log, float logData)
    {
        int number = 0;
        float lastNumber = logData;
        TextMeshProUGUI textLog = GetText((int)log);

        textLog.enabled = true;
        while (number < lastNumber)
        {
            if (_skip)
            {
                _audioSource.PlayOneShot(_textAudioClip, 0.3f);
                _skip = false;
                break;
            }
            _audioSource.PlayOneShot(_textAudioClip, 0.3f);
            textLog.text = $"{number}";
            number++;
            yield return new WaitForSeconds(0.05f);
        }

        textLog.text = $"{lastNumber.ToString("F0")}";
    }

    private void Skip()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _skip = true;
        }
    }
}
