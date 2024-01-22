using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ϳ��� ���� �ϳ��� �������� ����޴� Ŭ����
public class LevelHandler : MonoBehaviour
{
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

    public void InitKey() //���� Ŭ���� ��, ClearStationŬ�������� ȣ���ϴ� �Լ�
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
            // �̹� �ν��Ͻ��� �����ϸ� ���� ������ ���� �ı��Ͽ� �ߺ��� �����Ѵ�.
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()   //�׽�Ʈ �ڵ�
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            IsHasingKey();
        }
    }

    private void IsHasingKey()  //�׽�Ʈ �ڵ�
    {
        foreach (Define.KeyColor key in _hasKey)
        {
            print(key);
        }
    }
}
