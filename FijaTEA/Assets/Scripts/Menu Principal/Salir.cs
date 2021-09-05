using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir : MonoBehaviour
{

    private static Salir instance = null;

    private void Start()
    {
        restartVariables();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            restartVariables();
        }
    }

    private void restartVariables()
    {
        
        PlayerPrefs.SetInt("DesbloqueoSecuencia", 0);
        PlayerPrefs.SetInt("DesbloqueoOrden",0);
        PlayerPrefs.SetInt("Puntuacion", 0);
    }


    public static Salir Instance => instance;
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

}
