using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static SceneManagement _SceneManagement = new SceneManagement();

    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
        else if (instance != this)
        {
            Destroy(this.gameObject); 
        }
    }

}
