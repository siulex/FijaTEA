using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    private static GoBack instance = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeScene();

        }
    }

    private void ChangeScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Menu")
        {
            Application.Quit();
        }
        else
        {
            RestartVariables();
            SceneManager.LoadScene("Menu");
        }
    }

    private void RestartVariables()
    {

        PlayerPrefs.SetInt("Mistakes", 0);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Iteration", 0);


    }

    private void RestartVariablesFull()
    {
        RestartVariables();

        PlayerPrefs.SetInt("Current floor", 0);
    }


    public static GoBack Instance => instance;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void OnApplicationQuit()
    {
        RestartVariablesFull();
    }
}
