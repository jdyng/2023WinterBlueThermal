using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //데이터 영역============================================================================================
    #region Singleton
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();

                if (instance == null)
                {
                    GameObject singletonManagerObject = new GameObject("SingletonManager");
                    instance = singletonManagerObject.AddComponent<SoundManager>();
                }
            }

            return instance;
        }

        private set { }
    }
    #endregion

    #region PlayerSound
    [Header("PlayerSound")]
    [SerializeField] private AudioClip _playerFootstep;
    [SerializeField] private AudioClip _playerHit;
    #endregion

    #region ShootGunSound
    [Header("ShootGunSound")]
    [SerializeField] private AudioClip _onChainsaw;
    [SerializeField] private AudioClip _shootShotgun;
    [SerializeField] private AudioClip _shootGetlinggun;
    [SerializeField] private AudioClip _shootBajuka;
    #endregion

    #region SwapGunSound
    [Header("SwapGunSound")]
    [SerializeField] private AudioClip _swapChainsaw;
    [SerializeField] private AudioClip _swapShotgun;
    [SerializeField] private AudioClip _swapGetlinggun;
    [SerializeField] private AudioClip _swapBajuka;
    #endregion

    #region SpiderSound
    [Header("SpiderSound")]
    [SerializeField] private AudioClip _spiderAttack;
    [SerializeField] private AudioClip _spiderHit;
    [SerializeField] private AudioClip _spiderCry;
    [SerializeField] private AudioClip _spiderWalk;
    #endregion

    #region DoorSound
    [Header("DoorSound")]
    [SerializeField] private AudioClip _hasNoDoorKey;
    [SerializeField] private AudioClip _doorOpen;
    [SerializeField] private AudioClip _doorClose;
    #endregion

    #region ClearSound
    [Header("ClearSound")]
    [SerializeField] private AudioClip _notClear;
    [SerializeField] private AudioClip _Clear;
    #endregion
    //=======================================================================================================

    //함수 영역==============================================================================================

    #region Function of Sound
    public AudioClip GetPlayerSound(Define.PlayerSound playerSound)
    {
        switch (playerSound)
        {
            case Define.PlayerSound.FOOTSTEP:
                return _playerFootstep;
            case Define.PlayerSound.HIT:
                return _playerHit;
        }

        return null;
    }

    public void PlayPlayerSound(Define.PlayerSound playerSound, AudioSource audioSource)
    {
        switch (playerSound)
        {
            case Define.PlayerSound.FOOTSTEP:
                audioSource.PlayOneShot(_playerFootstep);
                break;
            case Define.PlayerSound.HIT:
                audioSource.PlayOneShot(_playerHit);
                break;
        }
    }
    #endregion

    #region Function of GunSound
    public AudioClip GetShootGunSound(Define.ShootGunSound ShootSound)
    {
        switch (ShootSound)
        {
            case Define.ShootGunSound.CHAINSAW:
                return _onChainsaw;
            case Define.ShootGunSound.SHOTGUN:
                return _shootShotgun;
            case Define.ShootGunSound.GETLINGGUN:
                return _shootGetlinggun;
            case Define.ShootGunSound.BAJUKA:
                return _shootBajuka;
        }

        return null;
    }

    public void PlayShootGunSound(Define.ShootGunSound shootGunSound, AudioSource audioSource)
    {
        switch (shootGunSound)
        {
            case Define.ShootGunSound.CHAINSAW:
                audioSource.PlayOneShot(_onChainsaw);
                break;
            case Define.ShootGunSound.SHOTGUN:
                audioSource.PlayOneShot(_shootShotgun);
                break;
            case Define.ShootGunSound.GETLINGGUN:
                audioSource.PlayOneShot(_shootGetlinggun);
                break;
            case Define.ShootGunSound.BAJUKA:
                audioSource.PlayOneShot((_shootBajuka));
                break;
        }
    }

    public AudioClip GetSwapGunSound(Define.SwapGunSound swapGunSound)
    {
        switch (swapGunSound)
        {
            case Define.SwapGunSound.CHAINSAW:
                return _swapChainsaw;
            case Define.SwapGunSound.SHOTGUN:
                return _swapShotgun;
            case Define.SwapGunSound.GETLINGGUN:
                return _swapGetlinggun;
            case Define.SwapGunSound.BAJUKA:
                return _swapBajuka;
        }

        return null;
    }
    #endregion

    public AudioClip GetSpiderSound(Define.SpiderSound monsterSound)
    {
        switch (monsterSound)
        {
            case Define.SpiderSound.ATTACK:
                return _spiderAttack;
            case Define.SpiderSound.HIT:
                return _spiderHit;
            case Define.SpiderSound.CRY:
                return _spiderCry;
            case Define.SpiderSound.WALK:
                return _spiderWalk;
        }

        return null;
    }

    public AudioClip GetDoorSound(Define.DoorSound doorSound)
    {
        switch (doorSound)
        {
            case Define.DoorSound.CANNOT:
                return _hasNoDoorKey;
            case Define.DoorSound.OPEN:
                return _doorOpen;
            case Define.DoorSound.CLOSE:
                return _doorClose;
        }

        return null;
    }

    public AudioClip GetClearSound(Define.ClearSound clearSound)
    {
        switch (clearSound)
        {
            case Define.ClearSound.CANNOT:
                return _notClear;
            case Define.ClearSound.CLEAR:
                return _notClear;
        }

        return null;
    }

    #region Singleton
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
