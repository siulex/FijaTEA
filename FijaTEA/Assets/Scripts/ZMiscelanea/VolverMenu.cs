using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverMenu : MonoBehaviour
{
    public GameObject boton;
    public int escena =0; // 0= caras, 1= secuencia

    void Start()
    {
        if (escena == 0)
        {
            
            if(PlayerPrefs.GetInt("DesbloqueoSecuencia") == 0)
                boton.SetActive(false);
        }
        else if (escena == 1)
        {
            if (PlayerPrefs.GetInt("DesbloqueoOrden") == 0)
                boton.SetActive(false);
        }
        
    }

    public void click()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }


}
