using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PuntuacionFinal : MonoBehaviour
{
    
    [SerializeField] private Image caritaBase;
     private Text mensaje;
    private Image[] caritas;
    public Canvas canvas;
    private int satisfaccion = 3;
    [SerializeField] private bool final = false;
    [SerializeField] private string sigEscena = "Final";


    private void Awake()
    {
        if (!final)
        {
            final = true;
            puntuar(3);
            final = false;
        }
        else
        {
            puntuar(3);
        }
      

        /*  int puntos = PlayerPrefs.GetInt("Puntuacion");

          switch (puntos)
          {
              case 1:
                  mensaje.text = "¡Buen trabajo!";
                  break;

              case 2:
                  mensaje.text = "¡Muy buen trabajo!";
                  break;
              case 3:
                  mensaje.text = "¡Perfecto, sigue así!";
                  break;
              default:
                  mensaje.text = "¡Buen trabajo!";
                  break;
          }

          //Colocamos caritas sonrientes
          Vector3 startPos = caritaBase.transform.position;
          float posX;
          caritas = new Image[puntos+1];
          Debug.Log(puntos);
          for (int i = 0; i <= puntos; i++)
          {
              Debug.Log("wii numero " + i);
              Image item; //instancia de la carta principal
              if (i == 0)
              {
                  item = caritaBase; //Si es la primera es la original
              }
              else
              {
                  item = Instantiate(caritaBase) as Image; //Clonamos la carita sonriente original
                  item.transform.SetParent(canvas.transform, false);

                  switch (puntos)
                  {

                      case 1:
                          posX = startPos.x + 260f * canvas.scaleFactor ;
                          item.transform.position = new Vector3(posX, startPos.y, startPos.z);
                          break;

                      case 2:
                          posX = (i * 175.3f) * canvas.scaleFactor + startPos.x;
                          item.transform.position = new Vector3(posX, startPos.y, startPos.z);
                          break;
                      case 3:
                          posX = (i * 131f) * canvas.scaleFactor + startPos.x ;
                          item.transform.position = new Vector3(posX, startPos.y, startPos.z);
                          break;

                  }
              }

              caritas[i] = item;


          }*/
    }

    public void puntuar(int puntos)
    {
        satisfaccion = puntos;
        CaritasGustado[] items = Object.FindObjectsOfType<CaritasGustado>();
        for (int i = 0; i < items.Length; i++)
        {
            Color opacidad = items[i].GetComponent<Image>().color;
            if (items[i].id > satisfaccion)
            {
                
                opacidad.a = 0.5f;
                items[i].GetComponent<Image>().color = opacidad;
            }
            else
            {
                opacidad.a = 1f;
                items[i].GetComponent<Image>().color = opacidad;
            }
        }
        if (!final)
        {
            StartCoroutine(DelaySiguienteEscena(1f));
        }
    }


    IEnumerator DelaySiguienteEscena(float time)
{
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sigEscena);
    }

public void BotonSalir()
    {
        Application.Quit();
        Debug.Log("Se ha salido correctamente");
    }

}

