using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    [SerializeField] private GameObject texto;
    // Start is called before the first frame update
    void Awake()
    {
        int puntos = PlayerPrefs.GetInt("Puntuacion");
        if (puntos > 6)
            puntos = 6;

        texto.GetComponent<UnityEngine.UI.Text>().text = puntos.ToString() + "/6";
    }


}
