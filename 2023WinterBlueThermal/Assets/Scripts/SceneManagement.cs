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

    public void MoveNextScene()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void MoveScene(Define.Scenes scene)
    { 
        if ((int)scene > (int)Define.Scenes.STAGE1)
        {
            SceneManager.LoadScene((int)Define.Scenes.STAGECLEAR);
        }
        else
        {
            SceneManager.LoadScene((int)scene);
        }
        
        currentScene = (int)scene;
        Debug.Log("Scene Moved to " + scene);
    }

    public int GetCurrentScene()
    {
        return currentScene;
    }

    public void OnClickNewGame()
    {
        SceneManager.LoadScene((int)Define.Scenes.STAGE1);
        Debug.Log("Scene Moved to " + Define.Scenes.STAGE1);
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