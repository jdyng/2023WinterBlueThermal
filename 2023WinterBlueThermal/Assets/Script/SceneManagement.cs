using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField]
    string MoveScene;

    public void SceneMove()
    {
        SceneManager.LoadScene(MoveScene);
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

/*    private void OnCollisionEnter(Collision collision)
    {
        SceneMove();
    }*/
}
