using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Caras : MonoBehaviour
{
    public GameObject opcion1;
    public GameObject opcion2;
    public GameObject opcion3;
    public string siguienteEscena = "MenuPrincipal";
    private bool elegido =false;
    private bool margen = false;
    private bool [] seleccion = new bool[2]; // Guarda si el botón ya ha sido elegido
    [SerializeField] private int desbloqueo = 0; // 0 false, 1 secuencia, 2 orden 
    public GameObject particulas;

    private void Start()
    {
        seleccion[0] = false;
        seleccion[1] = false;
        StartCoroutine(DelayElegir(2f));
    }

    IEnumerator DelayElegir(float time)
    {
        yield return new WaitForSeconds(time);

        ActivarBotones();
    }

    IEnumerator DelayError(float time)
    {
        DesactivarBotones();

        yield return new WaitForSeconds(time);

        ActivarBotones();
    }



    public void ActivarBotones()
    {
        if(!seleccion[0])
            opcion1.GetComponent<Image>().color = Color.white;

        if (!seleccion[1])
            opcion2.GetComponent<Image>().color = Color.white;

        opcion3.GetComponent<Image>().color = Color.white;

        margen = true;
    }

    public void DesactivarBotones()
    {
        margen = false;
        if (!seleccion[0])
            opcion1.GetComponent<Image>().color = new Color32(238, 234, 231, 255);

        if (!seleccion[1])
            opcion2.GetComponent<Image>().color = new Color32(238, 234, 231, 255);

        opcion3.GetComponent<Image>().color = new Color32(238, 234, 231, 255);
    }

    public void Opcion1()
    {
        if (!elegido&&margen)
        {
            opcion1.GetComponent<Image>().color = new Color32(238, 194, 163, 255); //Naranja grisaceo
            seleccion[0] = true;
            StartCoroutine(DelayError(1f));
        }

    }

    public void Opcion2()
    {
        if (!elegido&&margen)
        {
            
            opcion2.GetComponent<Image>().color = new Color32(238, 194, 163, 255); //Naranja grisaceo
            seleccion[1] = true;
            StartCoroutine(DelayError(1f));
        }
    }
    public void Opcion3()
    {
        if (!elegido&&margen)
        {
            elegido = true;

            opcion3.GetComponent<Image>().color = new Color32(184, 213, 195, 255); //Verde grisaceo

            int puntos = PlayerPrefs.GetInt("Puntuacion");
            
            PlayerPrefs.SetInt("Puntuacion", puntos + 1);


            

            StartCoroutine(DelaySiguienteEscena(2f));
        }
    }


    IEnumerator DelaySiguienteEscena(float time)
    {
        particulas.SetActive(true);
        DesbloquearContenido();
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(siguienteEscena);
    }
     private void DesbloquearContenido() { 
          if (siguienteEscena =="MenuPrincipal") {
                if (desbloqueo == 1) {
                
                    PlayerPrefs.SetInt("DesbloqueoSecuencia", 1);
                    
            }
            else if (desbloqueo == 2){
                    PlayerPrefs.SetInt("DesbloqueoOrden", 1);
                }
           }

      }
}

