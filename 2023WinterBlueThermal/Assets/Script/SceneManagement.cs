using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public enum Scenes
    {
        Title,
        Game1,
        Game2
    }

    public int currentScene;

    public void MoveScene(Scenes scene)
    {
        SceneManager.LoadScene((int)scene);
        currentScene = (int)scene;
        Debug.Log("Scene Moved to " + scene);
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