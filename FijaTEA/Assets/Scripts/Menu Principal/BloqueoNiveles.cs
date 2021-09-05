using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BloqueoNiveles : MonoBehaviour
{
    private bool desbloqueado = false;
    [SerializeField] private string sigEscena = "Cara1";
    [SerializeField] private GameObject cerrojo;
    public int id = 0;
    private int intentos = 0;

    private void Awake()
    {
        //Comprobamos de que tipo es (caras 1, secuencia 2 u ordenar 3) y comrpobamos valor interno de bloqueo
        switch (id){
            case 0:
                PlayerPrefs.SetInt("DesbloqueoCaras", 1); //Debug
                if (PlayerPrefs.GetInt("DesbloqueoCaras") != 0)
                {
                    desbloquear();
                }

                break;

            case 1:
                
                if (PlayerPrefs.GetInt("DesbloqueoSecuencia") != 0)
                {
                    desbloquear();
                }
                break;

            case 2:
               
                if (PlayerPrefs.GetInt("DesbloqueoOrden") != 0)
                {
                    desbloquear();
                }
                break;
        }
    }
    public void AbrirEscena() { 
        if (desbloqueado)
        {
            
            SceneManager.LoadScene(sigEscena);
        }
        else
        {
            Debug.Log("Contenido bloqueado");
            intentos++;
            if (intentos >= 5)
            {
                switch (id)
                {
                    case 0:
                        PlayerPrefs.SetInt("DesbloqueoCaras", 1);

                        break;

                    case 1:
                        PlayerPrefs.SetInt("DesbloqueoSecuencia", 1);
                        break;

                    case 2:
                        PlayerPrefs.SetInt("DesbloqueoOrden", 1);
                        break;
                }

                desbloquear();
            }
            
        }

    }

    private void desbloquear()
    {
        desbloqueado = true;
        cerrojo.SetActive(false);
        Debug.Log("Contenido desbloqueado");
    }


}
