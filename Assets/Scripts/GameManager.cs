using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool cameraNil = false;
    public bool movmentNil = false;

    public int startIndex;
    public int continueIndex;
    public int settingsIndex;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(Instance != this)
        {
            Debug.LogError("More than 1 instance of a manager", this);
            Destroy(this.gameObject);
        }
    }

    private void OnDisable()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

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
