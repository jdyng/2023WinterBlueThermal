using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;

    private Vector3 _moveDir;

    protected Rigidbody _rigid;

    [SerializeField]
    private int _hp; //ü��
    [SerializeField]
    protected int _currentHp; //���� ü��

    public void MoveEntity(Vector3 direction)
    {
        //_moveDir = transform.rotation * direction;
        //transform.position = new Vector3(
        //    transform.position.x + _moveDir.x * _moveSpeed * Time.deltaTime,
        //    transform.position.y + _moveDir.y * _moveSpeed * Time.deltaTime,
        //    transform.position.z + _moveDir.z * _moveSpeed * Time.deltaTime);
        Vector3 moveVelocity = transform.rotation * direction * _moveSpeed;
        _rigid.velocity = new Vector3(moveVelocity.x, _rigid.velocity.y, moveVelocity.z);
    }

    public void RotateY(float targetY)
    {
        transform.rotation = Quaternion.Euler(0, targetY, 0);
    }

    public void GetDamage(int hitDamage)
    {
        _currentHp -= hitDamage;
        Debug.Log($"������ {hitDamage}��ŭ ����");
        Dead();
    }

    protected virtual void Dead()
    {
        if (_currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Init()
    {
        _rigid = GetComponent<Rigidbody>();
        _currentHp = _hp;
    }

    protected virtual void OnUpdate() 
    {
        ClampHp();
    }

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        OnUpdate();
    }

    private void ClampHp()
    {
        if(_currentHp>_hp)
        {
            _currentHp = _hp;
        }
    }
}