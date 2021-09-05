using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Arrastrar : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler

{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [SerializeField] private Canvas canvas;
    private  Vector3 origen;
    bool acertado = false;

    public int id = 1;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        origen = rectTransform.position;
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Comienza");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Acaba");
        canvasGroup.alpha = 1f;
        if (!acertado)
        {
            canvasGroup.blocksRaycasts = true;
        }
        
        
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Click");
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta /canvas.scaleFactor;

    }

    public int GetId()
    {
        return id;
    }
    public void Reiniciar()
    {
        rectTransform.position = origen;
    }
    public void ApagarRaycast()
    {
        acertado = true;
        canvasGroup.blocksRaycasts = false;
    }


}
