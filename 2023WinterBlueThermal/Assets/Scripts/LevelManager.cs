using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ϳ��� ���� �ϳ��� �������� ����޴� Ŭ����
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
            // �̹� �ν��Ͻ��� �����ϸ� ���� ������ ���� �ı��Ͽ� �ߺ��� �����Ѵ�.
            Destroy(this.gameObject);
        }
    }

    private void Update()   //�׽�Ʈ �ڵ�
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
    }

    public void SetKey(Define.KeyColor key)
    {
        _hasKey.Add(key);
    }

    public List<Define.KeyColor> getKeys()
    {
        return _hasKey;
    }

    private void IsHasingKey()  //�׽�Ʈ �ڵ�
    {
        foreach(Define.KeyColor key in _hasKey)
        {
            print(key);
        }
    }
}
