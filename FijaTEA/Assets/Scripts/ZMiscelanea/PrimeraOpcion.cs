using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrimeraOpcion : MonoBehaviour
{
    public GameObject opcion1;
    public GameObject opcion2;
    public GameObject opcion3;
    private bool elegido =false;
    private bool siguiente = false;

    public void Opcion1()
    {
        if (!elegido)
        {
            opcion1.GetComponent<Image>().color = Color.red;
            opcion2.GetComponent<Image>().color = Color.green;
            elegido = true;
        }

    }

    public void Opcion2()
    {
        if (!elegido)
        {

            opcion2.GetComponent<Image>().color = Color.green;
            elegido = true;
            PlayerPrefs.SetInt("Puntuacion",1);

        }
    }
    public void Opcion3()
    {
        if (!elegido)
        {
            opcion3.GetComponent<Image>().color = Color.red;
            opcion2.GetComponent<Image>().color = Color.green;
            elegido = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (elegido && !siguiente)
        {
            siguiente = true;
            StartCoroutine(delaySiguienteEscena(1.5f));
        }
    }

    IEnumerator delaySiguienteEscena(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Escena2");
    }
}

