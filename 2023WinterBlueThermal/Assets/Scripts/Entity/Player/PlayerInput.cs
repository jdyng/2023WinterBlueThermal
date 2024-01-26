using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private float _rotateYSpeed = 10f;
    private float _inputX;
    private float _inputZ;
    private float _mouseY;

    private Vector3 _moveDirection;
    private Player _player;
    private WeaponController _weaponController;

    [SerializeField]
    private float _interactionRange = 5f;

    [Header("Keys")]
    [SerializeField]
    private KeyCode[] _keys;

    private UI_Popup _pauseUI;

    private void Awake()
    {
        Init();
    }
    protected void Init()
    {
        _player = GetComponent<Player>();
        _weaponController = GetComponentInChildren<WeaponController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _moveDirection = new Vector3(0, 0, 0);
        _mouseY = 0;

       
    }

    private void Update()
    {
        if(_pauseUI == null)
        {
            SetMoveDirection();
            ClampAngleY();
            if (Input.GetMouseButton(0))
            {
                _player.Shoot();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _player.ShootEnd();
            }

            for (int i = 0; i < _keys.Length; i++)
            {
                if (Input.GetKeyDown(_keys[i]))
                {
                    _player.SwichingWeapon(i);
                }
            }
        }


        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseUI = FindAnyObjectByType<UI_Popup>();
            if(_pauseUI == null)
            {
                Managers.UI.ShowPopupUI<UI_Pause>();
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                _pauseUI.GetComponent<UI_Popup>().Escape();
            }
        }

        Interact();
    }

    private void FixedUpdate()
    {
        _player.MoveEntity(_moveDirection);
        _player.RotateY(_mouseY);
    }

    private void SetMoveDirection()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        _inputZ = Input.GetAxisRaw("Vertical");
        _moveDirection = new Vector3(_inputX, 0, _inputZ);
    }

    private void ClampAngleY()
    {
        _mouseY += Input.GetAxis("Mouse X") * _rotateYSpeed;
        if (_mouseY < 0) { _mouseY += 360; }
        if (_mouseY > 360) { _mouseY -= 360; }
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Camera mainCamera = Camera.main;
            RaycastHit hit;

            Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * _interactionRange);
            Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, _interactionRange, LayerMask.GetMask("InteractiveObject"));
            IInteractable interactableObject = hit.collider.GetComponent<IInteractable>();

            if (interactableObject == null)
            {
                GameObject gameObject = hit.collider.gameObject;
                while (interactableObject == null)
                {
                    gameObject = gameObject.transform.parent.gameObject;
                    interactableObject = gameObject.GetComponent<IInteractable>();
                }
            }

            interactableObject.Interact();

        }
    }
}
