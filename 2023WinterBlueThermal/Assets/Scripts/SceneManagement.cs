using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    static SceneManagement s_instance;

    

    private int currentScene;

    public static SceneManagement Instance { get { Init(); return s_instance; } }

    private void Start()
    {
        Init();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject sceneManager = GameObject.Find("SceneManagement");
            if (sceneManager == null)
            {
                sceneManager = new GameObject { name = "SceneManagement" };
                sceneManager.AddComponent<SceneManagement>();
            }
            DontDestroyOnLoad(sceneManager);
            s_instance = sceneManager.GetComponent<SceneManagement>();
        }
    }

    // *****************************±â´É***************************

    public void MoveScene(Define.Scenes scene)
    {
        SceneManager.LoadScene((int)scene);
        currentScene = (int)scene;
        Debug.Log("Scene Moved to " + scene);
    }

    public int GetCurrentScene()
    {
        return currentScene;
    }

    public void OnClickNewGame()
    {
        SceneManager.LoadScene((int)Define.Scenes.Game1);
        Debug.Log("Scene Moved to " + Define.Scenes.Game1);
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}