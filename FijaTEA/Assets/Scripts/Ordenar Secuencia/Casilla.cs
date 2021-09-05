using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Casilla : MonoBehaviour, IDropHandler
{
    public int id = 1;
    public ControladorOrden controlador;
    private bool correcto = false;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag !=null && !correcto )
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            eventData.pointerDrag.GetComponent<Arrastrar>();

            if (id == eventData.pointerDrag.GetComponent<Arrastrar>().GetId())
            {
                GetComponent<Image>().color = Color.green;
                Debug.Log("¡Correcto!");
                correcto = true;
                eventData.pointerDrag.GetComponent<Arrastrar>().ApagarRaycast();
                controlador.Acierto();
            }
            else {
                GetComponent<Image>().color = Color.red;
                Debug.Log("¡Error!");
                eventData.pointerDrag.GetComponent<Arrastrar>().Reiniciar();
            }
            
        }else if (correcto)
        {
            eventData.pointerDrag.GetComponent<Arrastrar>().Reiniciar();
        }
    }

}
