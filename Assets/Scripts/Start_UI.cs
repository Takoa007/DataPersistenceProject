using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        AllManager.Instance.SaveLeaderboard();
#else
        Application.Quit();
        AllManager.Instance.SaveLeaderboard();
#endif
    }
}