using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//하나의 씬에 하나만 존재함을 보장받는 클래스
public class LevelHandler : MonoBehaviour
{
    private string _stageName;

    private int _numOfMonster = 0;
    private int _numOfItem = 0;
    private float _startTime = 0f;
    private float _parTime = 0f;

    private int _killsMonster = 0;
    private int _getsItem = 0;

    private static LevelHandler _instance = null;
    private List<Define.KeyColor> _hasKey = new List<Define.KeyColor>();
    public static LevelHandler Instance
    {
        get
        {
            return _instance;
        }
        private set { }
    }

    public void GetLogs(out string stageName, out int killsLog, out int itemsLog, out float timeLog, out float parLog)
    {
        stageName = _stageName;

        if(_killsMonster != 0) killsLog = (int)(((float)_killsMonster / (float)_numOfMonster) * 100);
        else killsLog = 0;

        if(_getsItem != 0) itemsLog = (int)(((float)_getsItem / (float)_numOfItem) * 100);
        else itemsLog = 0;

        timeLog = Time.time - _startTime;
        parLog = Time.time - _parTime;
    }

    public void InitKey() //레벨 클리어 시, ClearStation클래스에서 호출하는 함수
    {
        _hasKey.Clear();
    }

    public void SetKey(Define.KeyColor key)
    {
        _hasKey.Add(key);
    }

    public List<Define.KeyColor> getKeys()
    {
        return _hasKey;
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            // 이미 인스턴스가 존재하면 새로 생성된 것을 파괴하여 중복을 방지한다.
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _stageName = SceneManager.GetActiveScene().name;
        _numOfMonster = FindObjectsOfType<Enemy>().Length;
        _numOfItem = FindObjectsOfType<Item>().Length;
        _startTime = Time.time;
    }

    private void Update()
    {
        UpdateLogs();
    }

    private void UpdateLogs()
    {
        _killsMonster = _numOfMonster - FindObjectsOfType<Enemy>().Length;
        _getsItem = _numOfItem - FindObjectsOfType<Item>().Length;
    }
}
