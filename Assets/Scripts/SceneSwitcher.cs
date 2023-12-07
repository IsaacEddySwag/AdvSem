using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{
    public int startIndex;
    public int continueIndex;
    public int settingsIndex;

    public void StartGame()
    {
        SceneManager.LoadScene(startIndex);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(continueIndex);
    }

    public void Settings()
    {
        SceneManager.LoadScene(settingsIndex);
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
}
