using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorOrden : MonoBehaviour
{
    private int aciertos = 0;
    public int elementos = 5;
    public void Acierto()
    {
        aciertos++;
        if (aciertos == elementos)
        {
            int puntos = PlayerPrefs.GetInt("Puntuacion");
            PlayerPrefs.SetInt("Puntuacion", puntos + 1);
            StartCoroutine(DelaySiguienteEscena(1f));
        }
    }

    private IEnumerator DelaySiguienteEscena(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Cuestionario");
    }

}
