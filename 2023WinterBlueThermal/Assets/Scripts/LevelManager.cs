using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

//하나의 씬에 하나만 존재함을 보장받는 클래스
public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance = null;
    private List<Define.KeyColor> _hasKey = new List<Define.KeyColor>();

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

    private void Update()   //테스트 코드
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            IsHasingKey();
        }
    }

    public static LevelManager Instance
    {
        get
        {
            return _instance;
        }
        private set { }
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

    private void IsHasingKey()  //테스트 코드
    {
        foreach(Define.KeyColor key in _hasKey)
        {
            print(key);
        }
    }
}
